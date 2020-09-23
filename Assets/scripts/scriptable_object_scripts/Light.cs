using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Light", menuName = "Inventory/Light")]
public class Light : Item
{
	public Material lightMaterial;

	public void Awake()
	{
		OnEquip();
	}

    public override void OnEquip()
    {
        PlayerLineOfSightController.instance.SetMaterial(lightMaterial);
    }

	public Material GetLightingMaterial()
	{
		return lightMaterial;
	}
}
