using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
	public Transform target;

	const float minPathUpdateTime = .2f;
	const float pathUpdateMoveThreshold = .05f;

	public float moveSpeed = .0125f;

	Vector3[] path;

	int targetIndex;

	[SerializeField] private Rigidbody2D rigidbody;

	public void StartFollow()
	{
		if(GameState.playing == GameController.instance.GetCurrentState())
			StartCoroutine("UpdatePath");
	}

	IEnumerator UpdatePath()
	{
		if (Time.timeSinceLevelLoad < .3f)
		{
			yield return new WaitForSeconds(.3f);
		}

		PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);

		float sqrMoveThreshold = pathUpdateMoveThreshold * pathUpdateMoveThreshold;
		Vector3 targetPosOld = target.position;

		while (true)
		{
			yield return new WaitForSeconds(minPathUpdateTime);

			if ((target.position - targetPosOld).sqrMagnitude > sqrMoveThreshold)
			{
				PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
				targetPosOld = target.position;
			}

		}
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
	{
		if(pathSuccessful)
		{
			path = newPath;

			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath()
	{
		Vector3 currentWaypoint;

		if (path.Length > 0)
		{
			currentWaypoint = path[0];

			while (true)
			{
				if (transform.position == currentWaypoint)
				{
					targetIndex++;

					if (targetIndex >= path.Length)
					{
						yield break;
					}

					currentWaypoint = path[targetIndex];
				}

				Vector2 moveDirection = Vector3.MoveTowards(transform.position, currentWaypoint, moveSpeed * Time.deltaTime);
				rigidbody.MovePosition(moveDirection);

				float AngleRad = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x);
				float AngleDeg = (180 / Mathf.PI) * AngleRad;

				transform.rotation = Quaternion.Euler(0, 0, AngleDeg + 90f);

				yield return null;
			}
		
		}
	}
}
