using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
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
		Debug.Log("Opening Options"); 
	}

	public void QuitGame()
	{
		Debug.Log("Quitting Game");
		Application.Quit();
	}
}
