using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteractableController : BaseInteractableItemController
{
	public override void OnInteract()
	{
		HUDController.instance.SetText(interactionMessage[0], readTime); 
	}
}
