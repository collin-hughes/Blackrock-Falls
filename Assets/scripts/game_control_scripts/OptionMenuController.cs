using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Studio110Utils;

public class OptionMenuController : MonoBehaviour
{
	[SerializeField] private Button gameplayTabButton;
	[SerializeField] private Button volumeTabButton;

	[SerializeField] private GameObject gameplayTab;
	[SerializeField] private GameObject volumeTab;

	[SerializeField] private GameObject startMenu;
	[SerializeField] private GameObject optionsMenu;

	public void OnActivate()
	{
		gameplayTabButton.onClick.Invoke();
		gameplayTabButton.Select();
	}

	public void ShowVolumeTab()
	{
		gameplayTabButton.enabled = false;
		gameplayTabButton.enabled = true;
		UIUtilites.TogglePanels(ref gameplayTab, ref volumeTab);
	}

	public void ShowGameplayTab()
	{
		volumeTabButton.enabled = false;
		volumeTabButton.enabled = true;
		UIUtilites.TogglePanels(ref volumeTab, ref gameplayTab);
	}

	public void GoBack()
	{
		UIUtilites.TogglePanels(ref optionsMenu, ref startMenu);
	}
}
