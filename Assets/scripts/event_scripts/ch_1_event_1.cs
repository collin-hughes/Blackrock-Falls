using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ch_1_event_1 : BaseInteractableItemController
{
    [SerializeField] private GameObject hiddenPath;

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        Setup();

        spriteRenderer = hiddenPath.GetComponent<SpriteRenderer>();
    }
    public override void OnInteract()
    {
        uiController.SetText(interactionMessage[0], readTime);

        hiddenPath.GetComponent<BoxCollider2D>().enabled = false;

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, .85f);
    }
}
