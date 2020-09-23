using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusController : MonoBehaviour
{
	public int health;

	public GameObject blood;
	public GameObject deadBody;
	public GameObject bloodDecal;

	[SerializeField] protected string interactionMessage;

	[SerializeField] protected float readTime;

	[SerializeField] protected int eventParent;

	[SerializeField] protected int eventLinker;

	[SerializeField] protected string newTaskName;


	public void TakeDamage(int damage, RaycastHit2D attackRay)
	{
		health -= damage;

		Instantiate(blood, attackRay.point, transform.rotation); //, Quaternion.LookRotation(attackRay.normal), gameObject.transform);

		if (health <= 0)
		{
			OnDeath();
		}
	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		Instantiate(blood, transform.position, transform.rotation); //, Quaternion.LookRotation(attackRay.normal), gameObject.transform);

		if (health <= 0)
		{
			OnDeath();
		}
	}

	private void OnDeath()
	{
		if(eventLinker != -1)
		{
			EventController.instance.events[eventLinker].SetCompleted();
			HUDController.instance.SetText(interactionMessage, readTime);
			HUDController.instance.UpdateTask(newTaskName);
		}

		if(deadBody != null)
		{
			Instantiate(deadBody, transform.position, transform.rotation);
		}

		if(bloodDecal != null)
		{
			Instantiate(bloodDecal, transform.position, transform.rotation);
		}

		Destroy(gameObject);
	}
}
