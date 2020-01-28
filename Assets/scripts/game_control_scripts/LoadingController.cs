using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Studio110Utils;

public class LoadingController : MonoBehaviour
{
	#region Singleton
	public static LoadingController instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of LoadingControlller found!");
		}

		instance = this;
	}
	#endregion

	[SerializeField] private GameObject HUD;
	[SerializeField] private GameObject LoadScreen;

	[SerializeField] private AudioClip loadingMusic;

    public void LoadScene(int sceneIndex)
	{
		Studio110Utils.UIUtilites.TogglePanels(ref HUD, ref LoadScreen);

		//AudioController.instance.PlayMusic(loadingMusic);
		AudioController.instance.PlayMusic(loadingMusic);

		StartCoroutine(LoadAsync(sceneIndex));
	}

	IEnumerator LoadAsync(int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

		while (!operation.isDone)
		{
			LoadScreenController.instance.UpdateLoadText(operation.progress);

			yield return null;
		}

		AudioController.instance.StopMusic();
	}
}
