using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUIController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject mainHUD;

    //[SerializeField] private GameObject player;

    [SerializeField] public Slider healthBar;
    [SerializeField] public Slider staminaBar;

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

    public void SetText(string text, float timeout=3.0f)
    {
        infobox.CrossFadeAlpha(1.0f, 0.0f, false);
        infobox.SetText(text);
        infobox.CrossFadeAlpha(0.0f, timeout, false);
    }

    public void InventoryScreen()
    {
        inventoryScreen.SetActive(!inventoryScreen.activeSelf);
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
        slider.value = (value * 100) / maxValue;
    }
}
