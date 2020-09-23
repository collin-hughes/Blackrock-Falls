using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractableController : BaseInteractableItemController
{
	public override void OnInteract()
	{
		if (eventParent > -1 && EventController.instance.events[eventParent].GetCompleted())
		{
			EventController.instance.events[eventLinker].SetCompleted();
			HUDController.instance.SetText(interactionMessage[0], readTime);
			HUDController.instance.UpdateTask(newTaskName);
			Destroy(gameObject);
		}

		else
		{
			HUDController.instance.SetText(interactionMessage[1], readTime);
		}
	}
}
