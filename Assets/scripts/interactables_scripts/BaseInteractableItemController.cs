using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractableItemController : MonoBehaviour
{
    [SerializeField] protected string name;

    [SerializeField] protected string[] interactionMessage;

    [SerializeField] protected float readTime;

    protected bool interacted;

    protected GameObject playerCanvas;

    protected MainUIController uiController;

    public void Setup()
    {
        playerCanvas = GameObject.Find("mainCanvas");
        uiController = playerCanvas.GetComponent<MainUIController>();
    }


    public abstract void OnInteract();
}
