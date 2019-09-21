using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : MonoBehaviour
{
    [SerializeField] private GameObject raycastSource;

    private PlayerStatusController playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GetComponent<PlayerStatusController>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Sprint"))
        {

        }

        if(Input.GetButtonDown("Attack"))
        {

        }

        else if(Input.GetButtonDown("Interact"))
        {
            Interact();
        }

        
    }

    void Interact()
    {
        RaycastHit2D interactRay;

        if (interactRay = Physics2D.Raycast(raycastSource.transform.position, raycastSource.transform.up, .5f))
        {
            if (interactRay.transform.tag == "Interactable")
            {
                interactRay.transform.gameObject.GetComponent<BaseInteractableItemController>().OnInteract();
            }

            else if (interactRay.transform.tag == "Inventory")
            {
                interactRay.transform.gameObject.GetComponent<InventoryInteractableController>().OnInteract();
            }

            Debug.Log(interactRay.transform.name);
            Debug.DrawRay(raycastSource.transform.position, transform.up);
        }


    }

}
