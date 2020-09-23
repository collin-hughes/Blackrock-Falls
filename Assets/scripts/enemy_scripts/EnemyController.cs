using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] private EnemyMoveController moveController;

	public bool isAggro = false;

	public void OnAggro()
	{
		isAggro = true;
		moveController.StartFollow();
	}

	public void OffAggro()
	{
		isAggro = false;
		moveController.StopFollow();
	}
}

