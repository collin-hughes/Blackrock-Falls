using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteractableController : BaseInteractableItemController
{
    [SerializeField] private GameObject headlights;

    // Start is called before the first frame update
    void Start()
    {
        interacted = false;
    }

    override public void OnInteract()
    {
		if (eventParent > -1 && EventController.instance.events[eventParent].GetCompleted())
		{
			if (!interacted)
			{
				EventController.instance.events[eventLinker].SetCompleted();
				interacted = true;
				headlights.SetActive(true);
				HUDController.instance.SetText(interactionMessage[0], readTime);
				HUDController.instance.UpdateTask(newTaskName);
			}

			else
			{
				HUDController.instance.SetText(interactionMessage[1]);
			}
		}

		else
		{
			HUDController.instance.SetText(interactionMessage[2]);
		}
    }
}
