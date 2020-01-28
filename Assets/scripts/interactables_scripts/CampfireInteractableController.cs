using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireInteractableController :  BaseInteractableItemController
{

// Update is called once per frame
	public override void OnInteract()
	{
		Debug.Log("Something happens");
		HUDController.instance.SetText(interactionMessage[0], readTime);
	}
}
