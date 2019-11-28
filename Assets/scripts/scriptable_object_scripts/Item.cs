using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    public enum ItemTag
    {
        consumable, equipable, ammunition
    };

    public enum EquipableTag
    {
        weapon, light, NA
    };

    public bool isEquiped = false;
    public bool isDefaultItem = false;

    public string itemName = "New Item";
    public Sprite icon = null;
    public ItemTag itemTag;
    public EquipableTag equipableTag;
	public GameObject worldItem;
    public virtual void OnUse()
    {
        Debug.Log("Using " + itemName);
    }

    public virtual void OnEquip()
    {
        Debug.Log("Equipping " + itemName);
    }

	public virtual void OnReload()
	{
		Debug.Log("Reloading");
	}
}
