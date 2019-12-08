using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Studio110Utils;

public class StartMenuController : MonoBehaviour
{
	[SerializeField] private GameObject startMenu;
	[SerializeField] private GameObject optionsMenu;

	public void ContinueGame()
	{
		//Load last save state
		Debug.Log("Continuing Game");
	}

	public void NewGame()
	{
		//Start new game by loading first scene
		Debug.Log("Starting Game");

		LoadingController.instance.LoadScene(1);
	}

	public void LoadGame()
	{
		Debug.Log("Loading Game");
	}

	public void Options()
	{
		UIUtilites.TogglePanels(ref startMenu, ref optionsMenu);
		optionsMenu.GetComponent<OptionMenuController>().OnActivate();
	}

	public void QuitGame()
	{
		Debug.Log("Quitting Game");
		Application.Quit();
	}
}
