using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class Weapon : Item
{
    public float damage;
    public int magazineSize;
    public int loadedRound;

    public LineRenderer bullet;

    public override void OnUse()
    {
        if(loadedRound > 0)
        {
            RaycastHit2D fireRay;

            loadedRound--;
            MainUIController.instance.UpdateAmmoCounter(loadedRound, magazineSize);

            LineRenderer newBullet = Instantiate(bullet, PlayerActionController.instance.raycastSource.transform.position, PlayerActionController.instance.raycastSource.transform.rotation);

            if (fireRay = Physics2D.Raycast(PlayerActionController.instance.raycastSource.transform.position, PlayerActionController.instance.raycastSource.transform.up, 5))
            {

            }
        }
        
    }

    public override void OnEquip()
    {
        MainUIController.instance.UpdateAmmoCounter(loadedRound, magazineSize);
    }
}
