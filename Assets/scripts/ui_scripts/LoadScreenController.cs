using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Studio110Utils;

public class LoadScreenController : MonoBehaviour
{
	#region Singleton
	public static LoadScreenController instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of LoadScreenController found!");
		}

		instance = this;
	}
	#endregion

	[SerializeField] CanvasGroup loadScreenCanvas;

	[SerializeField] TextMeshProUGUI hintText;

	[SerializeField] TextMeshProUGUI loadText;

	[SerializeField] string[] hintList;

	private void Update()
	{
		
	}

	public void UpdateLoadText(float currentProgress)
	{
		currentProgress = (currentProgress / .9f) * 100;

		loadText.SetText("Loading... " + currentProgress + "%");
	}
}
