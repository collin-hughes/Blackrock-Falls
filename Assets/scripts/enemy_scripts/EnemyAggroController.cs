using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroController : MonoBehaviour
{
	[SerializeField] private EnemyController enemyController;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player" && !enemyController.isAggro)
		{
			enemyController.OnAggro();
			Debug.Log("aggro");
		}
	}
}
