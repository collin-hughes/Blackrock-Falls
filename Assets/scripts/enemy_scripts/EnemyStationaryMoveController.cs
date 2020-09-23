using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStationaryMoveController : EnemyMoveController
{
	bool followingPlayer = false;

	// Start is called before the first frame update
	new public void StartFollow()
	{
		if(GameState.playing == GameController.instance.GetCurrentState())
		{
			followingPlayer = true;
		}
	}

	new public void StopFollow()
	{
		if (GameState.playing == GameController.instance.GetCurrentState())
		{
			followingPlayer = false;
		}
	}

	public void Update()
	{
		if(followingPlayer)
		{
			transform.rotation = target.rotation;
		}
	}
}
