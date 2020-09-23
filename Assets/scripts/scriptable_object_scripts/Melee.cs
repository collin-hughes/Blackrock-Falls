using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee", menuName = "Inventory/Melee Weapon")]
public class Melee : Item
{
	public int damage;

	private int layerMask = 1<<14;

	public override void OnUse()
	{
		RaycastHit2D attackRay;// = new RaycastHit2D[3];

		attackRay = Physics2D.Raycast(PlayerActionController.instance.raycastSource.transform.position, PlayerActionController.instance.raycastSource.transform.up, range, layerMask);
		Debug.DrawRay(PlayerActionController.instance.raycastSource.transform.position, PlayerActionController.instance.raycastSource.transform.up * range);

		if (attackRay)
		{
			attackRay.transform.gameObject.GetComponent<EnemyStatusController>().TakeDamage(damage, attackRay);
		}
	}
}

