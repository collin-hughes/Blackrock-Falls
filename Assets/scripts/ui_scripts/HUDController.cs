using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Studio110Utils;

public class HUDController : MonoBehaviour
{
	#region Singleton
	public static HUDController instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of HUDController found!");
		}

		instance = this;
	}
	#endregion

	public Slider healthBar;
	public Slider staminaBar;

	private TextMeshProUGUI ammoCounter;
	private TextMeshProUGUI taskList;
	private TextMeshProUGUI infobox;

	private CanvasGroup mainHUDGroup; 

	// Start is called before the first frame update
	void Start()
    {
		ammoCounter = transform.Find("ammoCounter").GetComponent<TextMeshProUGUI>();
		taskList = transform.Find("taskList").GetComponent<TextMeshProUGUI>();
		infobox = transform.Find("infoText").GetComponent<TextMeshProUGUI>();

		healthBar = transform.Find("healthBar").GetComponent<Slider>();
		staminaBar = transform.Find("staminaBar").GetComponent<Slider>();

		mainHUDGroup = GetComponent<CanvasGroup>();
	}

	public void UpdateTask(string text)
	{
		taskList.SetText(text);
	}

	public void SetText(string text, float timeout = 3.0f)
	{
		//infobox.color = new Color(infobox.color.r, infobox.color.g, infobox.color.b, 255f);
		infobox.CrossFadeAlpha(1.0f, 0.0f, false);

		infobox.SetText(text);

		infobox.CrossFadeAlpha(0.0f, timeout, false);
	}
	public void UpdateHealth(int value, int maxValue)
	{
		healthBar.value = ((float)value / (float)maxValue) * 100;
	}

	public void UpdateStamina(int value, int maxValue)
	{
		staminaBar.value = ((float)value / (float)maxValue) * 100;
	}

	public void UpdateAmmoCounter(int loadedAmmo, int maxAmmo)
	{
		ammoCounter.SetText(loadedAmmo + " / " + maxAmmo);
	}

	public void Show()
	{
		mainHUDGroup.alpha = 1;
		mainHUDGroup.interactable = true;
		mainHUDGroup.blocksRaycasts = true;
	}

	public void Hide()
	{
		mainHUDGroup.alpha = 0;
		mainHUDGroup.interactable = false;
		mainHUDGroup.blocksRaycasts = false;
	}
}
