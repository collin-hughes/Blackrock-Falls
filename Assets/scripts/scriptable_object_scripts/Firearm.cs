﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Firearm", menuName = "Inventory/Ranged Weapon")]
public class Firearm : Item
{	public enum WeaponClass
	{
		single, spray
	};

	public WeaponClass weaponType;
	public AmmoType ammoType;

	public int damage;
    public int magazineSize;


	[System.NonSerialized]
	private int loadedRound;

	private int layerMask = 1<<14;

    public LineRenderer bullet;

	[SerializeField] private ParticleSystem muzzleFlash;
	[SerializeField] AudioClip[] soundFX = new AudioClip[2];

	public override void OnUse()
    {
		LineRenderer[] newBullet = new LineRenderer[3];

		RaycastHit2D[] fireArray = new RaycastHit2D[3];

		if (loadedRound > 0)
        {

			Instantiate(muzzleFlash, PlayerActionController.instance.raycastSource.transform);

			switch (weaponType)
			{
				case (WeaponClass.single):
					{
						loadedRound--;

						HUDController.instance.UpdateAmmoCounter(loadedRound, magazineSize);

						newBullet[0] = Instantiate(bullet, PlayerActionController.instance.raycastSource.transform.position, PlayerActionController.instance.transform.rotation);
						fireArray[0] = Physics2D.Raycast(PlayerActionController.instance.raycastSource.transform.position, PlayerActionController.instance.raycastSource.transform.up, range, layerMask);
						AudioController.instance.PlaySoundFX(soundFX[0]);
						Debug.DrawRay(PlayerActionController.instance.raycastSource.transform.position, PlayerActionController.instance.raycastSource.transform.up * 5);

						for (int i = 0; i < 1; i++)
						{
							if (fireArray[i])
							{
								fireArray[i].transform.gameObject.GetComponent<EnemyStatusController>().TakeDamage(damage, fireArray[i]);
							}
						}
						break;
					}

				case (WeaponClass.spray):
					{
						loadedRound--;

						HUDController.instance.UpdateAmmoCounter(loadedRound, magazineSize);

						newBullet[0] = Instantiate(bullet, PlayerActionController.instance.raycastSource.transform.position, PlayerActionController.instance.transform.rotation * Quaternion.Euler(0f, 0f, 5f));
						fireArray[0] = Physics2D.Raycast(PlayerActionController.instance.raycastSource.transform.position, Quaternion.AngleAxis(5f, PlayerActionController.instance.raycastSource.transform.forward) * PlayerActionController.instance.raycastSource.transform.up, range, layerMask);
						Debug.DrawRay(PlayerActionController.instance.raycastSource.transform.position, Quaternion.AngleAxis(5f, PlayerActionController.instance.raycastSource.transform.forward) * PlayerActionController.instance.raycastSource.transform.up * 5);

						newBullet[1] = Instantiate(bullet, PlayerActionController.instance.raycastSource.transform.position, PlayerActionController.instance.transform.rotation);
						fireArray[1] = Physics2D.Raycast(PlayerActionController.instance.raycastSource.transform.position, PlayerActionController.instance.raycastSource.transform.up, range, layerMask);
						Debug.DrawRay(PlayerActionController.instance.raycastSource.transform.position, PlayerActionController.instance.raycastSource.transform.up * 5);

						newBullet[2] = Instantiate(bullet, PlayerActionController.instance.raycastSource.transform.position, PlayerActionController.instance.transform.rotation * Quaternion.Euler(0f, 0f, -5f));
						fireArray[2] = Physics2D.Raycast(PlayerActionController.instance.raycastSource.transform.position, Quaternion.AngleAxis(-5f, PlayerActionController.instance.raycastSource.transform.forward) * PlayerActionController.instance.raycastSource.transform.up, range, layerMask);
						Debug.DrawRay(PlayerActionController.instance.raycastSource.transform.position, Quaternion.AngleAxis(-5f, PlayerActionController.instance.raycastSource.transform.forward) * PlayerActionController.instance.raycastSource.transform.up * 5);

						AudioController.instance.PlaySoundFX(soundFX[0]);

						for (int i = 0; i < fireArray.Length; i++)
						{
							if (fireArray[i])
							{
								Destroy(newBullet[i]);
								fireArray[i].transform.gameObject.GetComponent<EnemyStatusController>().TakeDamage(damage, fireArray[i]);
							}
						}
						
						break;
					}
				default:
					{
						break;
					}

			}
			
        }
        
    }

    public override void OnEquip()
    {
		HUDController.instance.UpdateAmmoCounter(loadedRound, magazineSize);
    }

	public override void OnReload()
	{
		loadedRound = PlayerAmmoController.instance.Reload(ammoType, loadedRound, magazineSize);

		HUDController.instance.UpdateAmmoCounter(loadedRound, magazineSize);
	}
}
