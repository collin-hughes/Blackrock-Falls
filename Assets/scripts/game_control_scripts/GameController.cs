using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject uiCanvas;

    private MainUIController uiController;

    public bool isPaused;


    //  UI Screen 0: Inventory Menu
    //  UI Screen 1: Pause Menu
    //  UI Screen 2: Game Over Screen
    //[SerializeField] private GameObject[] uiScreens = new GameObject[3];

    private void Start()
    {
        uiController = uiCanvas.GetComponent<MainUIController>();
        isPaused = false;
}

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(isPaused)
            {
                UnpauseGame();
            }

            else
            {
                PauseGame();
            }

            uiController.PauseScreen();
        }

        else if (Input.GetButtonDown("Inventory"))
        {
            if (isPaused)
            {
                UnpauseGame();
            }

            else
            {
                PauseGame();
            }

            uiController.InventoryScreen();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
    }
}
