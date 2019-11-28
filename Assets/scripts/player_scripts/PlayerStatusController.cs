using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour
{
    const int MAX_HEALTH = 100;
    const int MAX_STAMINA = 500;

    [SerializeField] private GameObject mainUI;

    [SerializeField] private int health = MAX_HEALTH;
    [SerializeField] private int stamina = MAX_STAMINA;
	[SerializeField] private int staminaLossRate;
	[SerializeField] private int staminaGainRate;

    public bool isSprinting;

    private bool isDead;
    private MainUIController uiController;


    // Start is called before the first frame update
    void Start()
    {
        //uiController = mainUI.GetComponent<MainUIController>();

        isDead = false;
        isSprinting = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (GameState.playing == GameController.instance.GetCurrentState())
		{
			if (Input.GetButton("Sprint") && (Input.GetButton("Horizontal") || Input.GetButton("Vertical")))
			{
				if (stamina > 0)
				{
					isSprinting = true;
					stamina -= staminaLossRate;

					//uiController.UpdateStatus(uiController.staminaBar, stamina, MAX_STAMINA);
					MainUIController.instance.UpdateStatus(MainUIController.instance.staminaBar, stamina, MAX_STAMINA);
				}

				else
				{
					isSprinting = false;
				}
			}

			else
			{
				isSprinting = false;

				if (stamina < MAX_STAMINA)
				{
					stamina += staminaGainRate;

					MainUIController.instance.UpdateStatus(MainUIController.instance.staminaBar, stamina, MAX_STAMINA);
				}
			}
		}
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

		MainUIController.instance.UpdateStatus(MainUIController.instance.healthBar, health, MAX_HEALTH);

        if (health <= 0)
        {
            isDead = true;
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
