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



	// Start is called before the first frame update
	void Start()
    {
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	
	

    public void InventoryScreen(bool state)
    {
        if(!state)
        {
            InventoryUIController.instance.Hide();
			HUDController.instance.Show();
        }

        else
        {
            InventoryUIController.instance.Show();
			HUDController.instance.Hide();
		}
    }

    public void PauseScreen(bool state, bool inventoryState)
    {
		if (!state && !inventoryState)
		{
			PauseMenuController.instance.Hide();
			HUDController.instance.Show();
		}

		else if (!state)
		{
			PauseMenuController.instance.Hide();
		}

		else
		{
			InventoryUIController.instance.Hide();
			HUDController.instance.Hide();
			PauseMenuController.instance.Show();
		}
	}

    public void MainHUD()
    {
		//mainHUD.SetActive(!mainHUD.activeSelf);
		//mainHUD.GetComponent<CanvasGroup>().alpha = 1;
    }
}
