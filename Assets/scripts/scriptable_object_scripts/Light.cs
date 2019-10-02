using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Light", menuName = "Inventory/Light")]
public class Light : Item
{
    public float intensityModifier;

    public override void OnEquip()
    {
        PlayerLineOfSightController.instance.SetIntensity(intensityModifier);
    }
}
