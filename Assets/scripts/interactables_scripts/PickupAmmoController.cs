using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAmmoController : BaseInteractableItemController
{
	public AmmoType ammoType;
	public int ammoAmount;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}

	public override void OnInteract()
	{
		PickUp();
	}

	private void PickUp()
	{
		bool wasPickedUp;

		Debug.Log("Picked up");

		HUDController.instance.SetText(interactionMessage[0], readTime);
		wasPickedUp = PlayerAmmoController.instance.PickUp(ammoType, ref ammoAmount);

		if (wasPickedUp)
		{
			Destroy(gameObject);
		}
	}
}
