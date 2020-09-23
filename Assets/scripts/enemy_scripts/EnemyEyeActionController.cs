using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyeActionController : MonoBehaviour
{
	[SerializeField] CapsuleCollider2D capsule;

	public int damage = 15;

	public void Attack()
	{
		capsule.enabled = true;
	}

	public void Retract()
	{
		capsule.enabled = false;	
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.tag == "Player")
		{
			collision.collider.gameObject.GetComponent<PlayerStatusController>().TakeDamage(damage);
		}
	}

}
