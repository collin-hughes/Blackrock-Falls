using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInteractableController : BaseInteractableItemController
{
    //[SerializeField] private string name;
    [SerializeField] private GameObject[] inventory;

    [SerializeField] private GameObject inventoryManager;

    private void Start()
    {
        Setup();
    }

    override public void OnInteract()
    {

        uiController.SetText(interactionMessage[0], readTime);
        //inventoryManager.OpenInventory(name, inventory);
    }

}
