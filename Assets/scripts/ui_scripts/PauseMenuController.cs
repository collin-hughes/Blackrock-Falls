using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
	#region Singleton
	public static PauseMenuController instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of PauseMenuController found!");
		}

		instance = this;
	}
	#endregion


	private CanvasGroup pauseGroup;

	void Start()
	{
		pauseGroup = GetComponent<CanvasGroup>();
	}

	public void Show()
	{
		pauseGroup.alpha = 1;
		pauseGroup.interactable = true;
		pauseGroup.blocksRaycasts = true;
	}

	public void Hide()
	{
		pauseGroup.alpha = 0;
		pauseGroup.interactable = false;
		pauseGroup.blocksRaycasts = false;
	}
}
