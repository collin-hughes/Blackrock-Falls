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

	public GameObject blood;

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

					HUDController.instance.UpdateStamina(stamina, MAX_STAMINA);
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
			
					HUDController.instance.UpdateStamina(stamina, MAX_STAMINA);
				}
			}
		}
    }

    public void TakeDamage(int damage, RaycastHit2D attackRay)
    {
        health -= damage;

		Instantiate(blood, attackRay.point, transform.rotation);

		HUDController.instance.UpdateHealth(health, MAX_HEALTH);

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
