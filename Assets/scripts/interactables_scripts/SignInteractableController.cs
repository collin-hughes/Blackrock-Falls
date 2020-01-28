using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteractableController : BaseInteractableItemController
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public override void OnInteract()
    {
		HUDController.instance.SetText(interactionMessage[0], readTime);
    }
}
