using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType : int
{
	glockAmmo = 0,
	magnumAmmo = 1,
	shotgunAmmo = 2,
	rifleAmmo = 3  
};

public class PlayerAmmoController : MonoBehaviour
{
	#region Singleton
	public static PlayerAmmoController instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of PlayerAmmoController found!");
		}

		instance = this;
	}
	#endregion

	[System.Serializable]
	public struct AmmoItem
	{
		public AmmoType ammoType;
		public string ammoName;
		public int maxCapacity;
		public int stock;
	}

	public List<AmmoItem> ammoInventory = new List<AmmoItem>();

	public bool PickUp(AmmoType ammoType, ref int ammoAmount)
	{
		int stockSpace;
		AmmoItem held;

		held = ammoInventory[(int)ammoType];

		stockSpace = ammoInventory[(int)ammoType].maxCapacity - held.stock;

		held.stock += Mathf.Min(stockSpace, ammoAmount);

		ammoInventory[(int)ammoType] = held;

		if (ammoAmount - stockSpace > 0)
		{
			ammoAmount -= stockSpace;
			return false;
		}

		else
		{
			return true;
		}
	}

	public int Reload(AmmoType ammoType, int loadedRound, int magazineSize)
	{
		AmmoItem held;
		int magSpace;

		magSpace = magazineSize - loadedRound;

		held = ammoInventory[(int)ammoType];

		if (held.stock < magSpace)
		{
			loadedRound += held.stock;
			held.stock = 0;
		}

		else
		{
			loadedRound += magSpace;
			held.stock -= magSpace;
		}

		ammoInventory[(int)ammoType] = held;

		return loadedRound;
	}
}
