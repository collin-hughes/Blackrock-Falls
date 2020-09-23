using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour
{
	#region Singleton
	public static PlayerStatusController instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of PlayerStatusController found!");
		}

		else
		{
			instance = this;
		}

	}
	#endregion


	const int MAX_HEALTH = 100;
    const int MAX_STAMINA = 500;



    [SerializeField] private GameObject mainUI;

    [SerializeField] private float health = MAX_HEALTH;
    [SerializeField] private float stamina = MAX_STAMINA;
	[SerializeField] private float staminaLossRate;
	[SerializeField] private float staminaGainRate;

    public bool isSprinting;
	public bool isRecovering;

    private bool isDead;
    private MainUIController uiController;

	public GameObject blood;

	// Start is called before the first frame update
	void Start()
    {
        isDead = false;
        isSprinting = false;
		isRecovering = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (GameState.playing == GameController.instance.GetCurrentState())
		{
			if (Input.GetButton("Sprint") && (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && stamina > 0 && !isRecovering)
			{
				isSprinting = true;
				stamina -= staminaLossRate;

				HUDController.instance.UpdateStamina((int)stamina, MAX_STAMINA);
			}

			else
			{
				isSprinting = false;
				isRecovering = true;
			
				if (stamina < MAX_STAMINA)
				{
					stamina += staminaGainRate;
			
					HUDController.instance.UpdateStamina((int)stamina, MAX_STAMINA);
				}

				else
				{
					isRecovering = false;
				}
			}
		}
    }

    public void TakeDamage(int damage, RaycastHit2D attackRay)
    {
        health -= damage;

		Instantiate(blood, attackRay.point, transform.rotation);

		HUDController.instance.UpdateHealth((int)health, MAX_HEALTH);

        if (health <= 0)
        {
            isDead = true;
        }
    }

	public void TakeDamage(int damage)
	{
		health -= damage;

		Instantiate(blood, transform.position, transform.rotation);

		HUDController.instance.UpdateHealth((int)health, MAX_HEALTH);

		if (health <= 0)
		{
			isDead = true;
		}
	}

	public void HealDamage(int healing)
	{
		health += healing;

		HUDController.instance.UpdateHealth((int)health, MAX_HEALTH);

		Mathf.Clamp(health, 0, MAX_HEALTH);
	}

	public bool IsDead()
    {
        return isDead;
    }
}
