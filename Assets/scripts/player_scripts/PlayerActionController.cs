using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : MonoBehaviour
{
    #region Singleton
    public static PlayerActionController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Action found!");
        }

        instance = this;
    }
    #endregion

    public GameObject raycastSource;

	[SerializeField] private float useDistance;
	[SerializeField] private LayerMask interactableMask;


    private PlayerStatusController playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GetComponent<PlayerStatusController>();    
    }

    // Update is called once per frame
    void Update()
    {
		if (GameState.playing == GameController.instance.GetCurrentState())
		{
			if (Input.GetButton("Sprint"))
			{

			}

			if (Input.GetButtonDown("Attack"))
			{
				try
				{
					PlayerInventoryController.instance.equipedWeapon.OnUse();
				}

				catch
				{
					HUDController.instance.SetText("I don't have a weapon");
				}
			}

			else if (Input.GetButtonDown("Reload"))
			{
				try
				{
					PlayerInventoryController.instance.equipedWeapon.OnReload();
				}

				catch
				{
					HUDController.instance.SetText("I don't have anything to reload");
				}
			}

			else if (Input.GetButtonDown("Interact"))
			{
				Interact();
			}
		}
	}

    void Interact()
    {
        RaycastHit2D interactRay;

        if (interactRay = Physics2D.Raycast(raycastSource.transform.position, raycastSource.transform.up, useDistance, interactableMask))
        {
            if (interactRay.transform.tag == "Interactable")
            {
                interactRay.transform.gameObject.GetComponent<BaseInteractableItemController>().OnInteract();
            }

            else if (interactRay.transform.tag == "Inventory")
            {
                interactRay.transform.gameObject.GetComponent<InventoryInteractableController>().OnInteract();
            }

            Debug.Log(interactRay.transform.name);
            Debug.DrawRay(raycastSource.transform.position, transform.up);
        }


    }

}
