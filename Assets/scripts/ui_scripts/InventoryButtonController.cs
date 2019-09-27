
using UnityEngine;
using UnityEngine.UI;

public class InventoryButtonController : MonoBehaviour
{
    public Item item;

    [SerializeField] private Image icon;

    [SerializeField] private GameObject equipableMenu;
    [SerializeField] private GameObject consumableMenu;

    // Start is called before the first frame update
    void Start()
    {
        item = null;
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot ()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void SpawnMenu()
    {
        if(item != null)
        {
            if (item.itemTag == Item.ItemTag.equipable)
            {
                equipableMenu.GetComponent<UseMenuController>().ShowMenu();
            }

            else if (item.itemTag == Item.ItemTag.consumable)
            {
                consumableMenu.GetComponent<UseMenuController>().ShowMenu();
            }
        }
    }


}
