using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUIController : MonoBehaviour
{
    #region Singleton
    public static MainUIController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of MainUIController found!");
        }

        instance = this;
    }
    #endregion

    [SerializeField] private GameObject inventoryScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject mainHUD;

    //[SerializeField] private GameObject player;

    [SerializeField] public Slider healthBar;
    [SerializeField] public Slider staminaBar;
    [SerializeField] public TextMeshProUGUI ammoCounter;
	[SerializeField] public TextMeshProUGUI taskList;

	private TextMeshProUGUI infobox;
   // private PlayerStatusController playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        infobox = mainHUD.transform.Find("infoText").GetComponent<TextMeshProUGUI>();
        //playerStatus = player.GetComponent<PlayerStatusController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void UpdateTask(string text)
	{
		taskList.SetText(text);
	}

    public void SetText(string text, float timeout=3.0f)
    {
        infobox.CrossFadeAlpha(1.0f, 0.0f, false);
        infobox.SetText(text);
        infobox.CrossFadeAlpha(0.0f, timeout, false);
    }

    public void InventoryScreen(bool state)
    {
        if(!state)
        {
            InventoryUIController.instance.Hide();
        }

        else
        {
            InventoryUIController.instance.Show();
        }

        MainHUD();
    }

    public void PauseScreen()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);
        MainHUD();
    }

    public void MainHUD()
    {
        mainHUD.SetActive(!mainHUD.activeSelf);
    }

    public void UpdateStatus(Slider slider, int value, int maxValue)
    {
        slider.value = ((float)value / (float)maxValue) * 100;
    }

    public void UpdateAmmoCounter(int loadedAmmo, int maxAmmo)
    {
        ammoCounter.SetText(loadedAmmo + " / " + maxAmmo);
    }

	

}
