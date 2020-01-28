using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    #region Singleton
    public static PlayerInventoryController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }

		else
		{
			instance = this;
			DontDestroyOnLoad(this);
		}
		
	}
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 9;

    public List<Item> items = new List<Item>();

    public Item equipedWeapon = null;
    public Item equipedLight = null;


    public bool Add (Item item)
    {
        if(!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                HUDController.instance.SetText("I don't have enough room for that.");
                return false;
            }

            items.Add(item);

            if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void EquipWeapon(InventoryButtonController slot)
    {
        Item tempItem;

        tempItem = slot.item; 

        Remove(slot.item);

        if(equipedWeapon != null)
        {
            Add(equipedWeapon);
        }

        equipedWeapon = tempItem;

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void EquipLight(InventoryButtonController slot)
    {
        Item tempItem;

        tempItem = slot.item;

        Remove(slot.item);

        if (equipedLight != null)
        {
            Add(equipedLight);
        }

        equipedLight = tempItem;

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
