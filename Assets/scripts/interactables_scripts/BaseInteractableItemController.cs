using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractableItemController : MonoBehaviour
{
    [SerializeField] protected string name;

    [SerializeField] protected string[] interactionMessage;

    [SerializeField] protected float readTime;

	[SerializeField] protected int eventParent;

	[SerializeField] protected int eventLinker;

	[SerializeField] protected string newTaskName;

    protected bool interacted;

    public abstract void OnInteract();
}
