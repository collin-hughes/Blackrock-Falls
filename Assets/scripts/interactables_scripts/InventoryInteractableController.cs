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
    }

    override public void OnInteract()
    {
		HUDController.instance.SetText(interactionMessage[0], readTime);
    }

}
