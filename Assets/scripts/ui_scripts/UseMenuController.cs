using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMenuController : MonoBehaviour
{
    private bool isActive;
    private int timeout;
    private int counter;

    CanvasGroup canvasGroup;

    [SerializeField] private GameObject inventorySlot;

    private InventoryButtonController inventorySlotController;

    // Start is called before the first frame update
    void Start()
    {
        inventorySlotController = inventorySlot.GetComponent<InventoryButtonController>();
        canvasGroup = GetComponent<CanvasGroup>();
        HideMenu();
    }

	private void Update()
	{
		
	}

	public void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.ignoreParentGroups = false;

        StartCoroutine(Timeout());
    }

    public void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.ignoreParentGroups = false;
    }

    IEnumerator Timeout()
    {
        timeout = 1;
        counter = 0;

        while(counter < timeout)
        {
            counter++;

            yield return new WaitForSecondsRealtime(1.0f);
        }
        
        HideMenu();
    }
	public void Use()
	{
		inventorySlotController.item.OnUse();
		inventorySlotController.ClearSlot();
	}

    public void Equip()
    {
        if(inventorySlotController.item.equipableTag == Item.EquipableTag.weapon)
        {
            inventorySlotController.item.OnEquip();
            PlayerInventoryController.instance.EquipWeapon(inventorySlotController);
        }

        else if(inventorySlotController.item.equipableTag == Item.EquipableTag.light)
        {
            inventorySlotController.item.OnEquip();
            PlayerInventoryController.instance.EquipLight(inventorySlotController);
            
        }

        HideMenu();
    }

	public void UnEquip()
	{
		Debug.Log("Unequiping");
	}

	public void Drop()
	{
		Vector3 currentPosition = GameObject.Find("player").transform.position;

		GameObject droppedItem = Instantiate(inventorySlotController.item.worldItem, currentPosition, new Quaternion(), GameObject.Find("items").transform);

		PlayerInventoryController.instance.Remove(inventorySlotController.item);

		HideMenu();
	}
}
