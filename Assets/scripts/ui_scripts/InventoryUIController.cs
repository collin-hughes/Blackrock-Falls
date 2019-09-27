using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    #region Singleton
    public static InventoryUIController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of InventoryUIController found!");
        }

        instance = this;
    }
    #endregion

    public Transform itemSlotParent;

    InventoryButtonController[] slots;

    [SerializeField] InventoryButtonController equipedWeapon;
    [SerializeField] InventoryButtonController equipedLight;

    PlayerInventoryController inventory;

    CanvasGroup inventoryGroup;

    // Start is called before the first frame update
    void Start()
    {
        inventory = PlayerInventoryController.instance;
        inventory.onItemChangedCallback += UpdateUI;

        inventoryGroup = GetComponent<CanvasGroup>();

        slots = itemSlotParent.GetComponentsInChildren<InventoryButtonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int index = 0; index < slots.Length; index++)
        {
            if (index < inventory.items.Count)
            {
                slots[index].AddItem(inventory.items[index]);
            }

            else
            {
                slots[index].ClearSlot();
            }
        }

        if(PlayerInventoryController.instance.equipedWeapon != null)
        {
            equipedWeapon.AddItem(PlayerInventoryController.instance.equipedWeapon);
        }
        
        else
        {
            equipedWeapon.ClearSlot();
        }

        if (PlayerInventoryController.instance.equipedLight != null)
        {
            equipedLight.AddItem(PlayerInventoryController.instance.equipedLight);
        }

        else
        {
            equipedLight.ClearSlot();
        }


    }

    public void Show()
    {
        inventoryGroup.alpha = 1;
        inventoryGroup.interactable = true;
        inventoryGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        inventoryGroup.alpha = 0;
        inventoryGroup.interactable = false;
        inventoryGroup.blocksRaycasts = false;
    }
}
