using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyeAggroController : MonoBehaviour
{
	[SerializeField] private EnemyController enemyController;
	[SerializeField] private Animator eyeAnimator;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player" && !enemyController.isAggro)
		{
			enemyController.OnAggro();
			eyeAnimator.SetBool("aggro", true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player" && enemyController.isAggro)
		{
			enemyController.OffAggro();
			eyeAnimator.SetBool("aggro", false);
		}
	}
}
