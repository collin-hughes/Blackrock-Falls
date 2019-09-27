using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractableController : BaseInteractableItemController
{
    [SerializeField] private bool isLocked;
    [SerializeField] private int doorID;

    [SerializeField] private GameObject openDoor;

    [SerializeField] private GameObject roof;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        //isOpen = false;

        spriteRenderer = roof.GetComponent<SpriteRenderer>();
    }

    public override void OnInteract()
    {
        Debug.Log("Door opening");

        if (isLocked)
        {
            MainUIController.instance.SetText("This door is locked.");

            return;
        }

        openDoor.SetActive(true);
        gameObject.SetActive(false);

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, .25f);
    }
}
