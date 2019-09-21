using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerBase : MonoBehaviour
{
    protected GameObject playerCanvas;

    protected MainUIController uiController;

    // Start is called before the first frame update
    void Start()
    {
        playerCanvas = GameObject.Find("mainCanvas");
        uiController = playerCanvas.GetComponent<MainUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);

}
