using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusController : MonoBehaviour
{
	public int health;

	public GameObject blood;

	private bool isDead;

	private void Start()
	{
		isDead = true;
	}

	public void TakeDamage(int damage, RaycastHit2D attackRay)
	{
		health -= damage;

		Instantiate(blood, attackRay.point, transform.rotation); //, Quaternion.LookRotation(attackRay.normal), gameObject.transform);

		if (health <= 0)
		{
			OnDeath();
		}
	}

	private void OnDeath()
	{
		isDead = true;
		Destroy(gameObject);
	}
}
