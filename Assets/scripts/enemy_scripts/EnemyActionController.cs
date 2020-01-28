﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionController : MonoBehaviour
{
	[SerializeField] private int damage;
	[SerializeField] private float range;

	[SerializeField] private GameObject attackSource;

	private int layerMask = 1 << 9;

	public void OnCollisionEnter2D(Collision2D collision)
	{
		RaycastHit2D attackRay;

		if (collision.transform.tag == "Player")
		{
			attackRay = Physics2D.Raycast(attackSource.transform.position, -transform.up, range, layerMask);
			
			if(attackRay)
			{
				Debug.Log("Chomp");
				collision.transform.GetComponent<PlayerStatusController>().TakeDamage(damage, attackRay);
				collision.transform.GetComponent<Rigidbody2D>().AddForce(-transform.up * 50);
			}


		}
	}
}
