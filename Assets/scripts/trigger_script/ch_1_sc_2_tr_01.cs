using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ch_1_sc_2_tr_01 : TriggerBase
{
	[SerializeField] protected string name;

	[SerializeField] protected string[] interactionMessage;

	[SerializeField] protected float readTime;

	[SerializeField] protected int eventParent;

	[SerializeField] protected int eventLinker;

	[SerializeField] protected string newTaskName;

	[SerializeField] protected GameObject sceneTransition;

	protected bool interacted;

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			if (eventParent > -1 && EventController.instance.events[eventParent].GetCompleted())
			{
				if (!interacted)
				{
					EventController.instance.events[eventLinker].SetCompleted();
					interacted = true;
					sceneTransition.SetActive(true);
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
}
