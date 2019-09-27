using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GameController found!");
        }

        instance = this;
    }
    #endregion

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject uiCanvas;

    private MainUIController uiController;

    public bool isPaused;
    public bool pauseMenuActive;
    public bool inventoryMenuActive;
    public bool hudActive;

    //  UI Screen 0: Inventory Menu
    //  UI Screen 1: Pause Menu
    //  UI Screen 2: Game Over Screen
    //[SerializeField] private GameObject[] uiScreens = new GameObject[3];

    private void Start()
    {
        isPaused = false;
        inventoryMenuActive = false;
        pauseMenuActive = false;
        hudActive = true;
}

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            inventoryMenuActive = false;
            hudActive = false;
            pauseMenuActive = !pauseMenuActive;

            if (isPaused)
            {
                UnpauseGame();
            }

            else
            {
                PauseGame();
            }

            MainUIController.instance.PauseScreen();
        }

        else if (Input.GetButtonDown("Inventory"))
        {
            inventoryMenuActive = !inventoryMenuActive;
            hudActive = false;
            pauseMenuActive = false;

            if (isPaused)
            {
                UnpauseGame();
            }

            else
            {
                PauseGame();
            }

            MainUIController.instance.InventoryScreen(inventoryMenuActive);
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
