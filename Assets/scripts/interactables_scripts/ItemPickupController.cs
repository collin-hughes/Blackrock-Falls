using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupController : BaseInteractableItemController
{
    public Item item;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnInteract()
    {
        PickUp();
    }

    private void PickUp()
    {
        bool wasPickedUp;

        MainUIController.instance.SetText(interactionMessage[0], readTime);
        wasPickedUp = PlayerInventoryController.instance.Add(item);

        if(wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
