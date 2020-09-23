using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item
{
	public int healthAmount;

	public override void OnUse()
	{
		Debug.Log("Using...");
		PlayerStatusController.instance.HealDamage(healthAmount);
	}
}
