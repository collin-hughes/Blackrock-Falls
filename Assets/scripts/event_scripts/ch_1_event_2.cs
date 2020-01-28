using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ch_1_event_2 : BaseInteractableItemController
{
    [SerializeField] private GameObject hiddenPath;

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = hiddenPath.GetComponent<SpriteRenderer>();
    }
    public override void OnInteract()
    {
		if (eventParent > -1 && EventController.instance.events[eventParent].GetCompleted()) 
		{
			EventController.instance.events[eventLinker].SetCompleted();

			HUDController.instance.SetText(interactionMessage[0], readTime);

			hiddenPath.GetComponent<BoxCollider2D>().enabled = false;

			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, .85f);

			HUDController.instance.UpdateTask(newTaskName);
		}

		else
		{
			HUDController.instance.SetText(interactionMessage[1]);
		}
        
    }
}
