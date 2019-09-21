using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireInteractableController :  BaseInteractableItemController
{
    // Start is called before the first frame update
    void Start()
{
    Setup();
}

// Update is called once per frame
public override void OnInteract()
{
    uiController.SetText(interactionMessage[0], readTime);
}

}
