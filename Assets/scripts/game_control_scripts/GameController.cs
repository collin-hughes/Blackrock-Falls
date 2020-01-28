using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
	playing, paused
}

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

	[SerializeField] private AudioClip sceneMusic;

	[SerializeField] private Texture2D combatCursor;

    private MainUIController uiController;

	private GameState currentState;

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
		currentState = GameState.playing;
		AudioController.instance.PlayMusic(sceneMusic);
		Cursor.SetCursor(combatCursor, Vector2.zero, CursorMode.Auto);
	}

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
			if (pauseMenuActive && !inventoryMenuActive)
            {
				Cursor.SetCursor(combatCursor, Vector2.zero, CursorMode.Auto);
				UnpauseGame();
				currentState = GameState.playing;
				Time.timeScale = 1.0f;
			}

			else if(pauseMenuActive && inventoryMenuActive)
			{
				MainUIController.instance.InventoryScreen(inventoryMenuActive);
				UnpauseGame();
			}

            else
            {
				Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
				currentState = GameState.paused;
				Time.timeScale = 0.0f;
			}

			pauseMenuActive = !pauseMenuActive;
			MainUIController.instance.PauseScreen(pauseMenuActive, inventoryMenuActive);
		}

        else if (Input.GetButtonDown("Inventory") && !pauseMenuActive)
        {
            inventoryMenuActive = !inventoryMenuActive;
            pauseMenuActive = false;
		
            if (inventoryMenuActive)
            {
				Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
				currentState = GameState.paused;
				Time.timeScale = 0.0f;
				AudioController.instance.PlaySoundFX(InventoryUIController.instance.soundFX[1]);

			}

            else
           {
				Cursor.SetCursor(combatCursor, Vector2.zero, CursorMode.Auto);
				currentState = GameState.playing;
				Time.timeScale = 1.0f;
				AudioController.instance.PlaySoundFX(InventoryUIController.instance.soundFX[0]);
			}

            MainUIController.instance.InventoryScreen(inventoryMenuActive);
        }
    }
	public GameState GetCurrentState()
	{
		return currentState;
	}

    private void PauseGame()
    {

	}

    private void UnpauseGame()
    {
		
	}
}

