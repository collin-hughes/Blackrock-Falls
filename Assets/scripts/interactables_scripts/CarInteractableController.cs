using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteractableController : BaseInteractableItemController
{
    [SerializeField] private GameObject headlights;

    // Start is called before the first frame update
    void Start()
    {
        interacted = false;
    }

    override public void OnInteract()
    {
        if(!interacted)
        {
            interacted = true;
            headlights.SetActive(true);
            MainUIController.instance.SetText(interactionMessage[0], readTime);
        }

        else
        {
            MainUIController.instance.SetText(interactionMessage[1]);
        }

    }
}
