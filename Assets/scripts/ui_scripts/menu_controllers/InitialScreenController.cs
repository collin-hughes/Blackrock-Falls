using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Studio110Utils;

public class InitialScreenController : MonoBehaviour
{
	//[SerializeField] private
	public GameObject startText;
	//[SerializeField] private 
	public GameObject startMenu;

	//[SerializeField] private Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
		{
			/*startTextCanvasGroup.alpha = 0f;
			startTextCanvasGroup.interactable = false;
			startTextCanvasGroup.blocksRaycasts = false;

			startMenuCanvasGroup.alpha = 1f;
			startMenuCanvasGroup.interactable = true;
			startMenuCanvasGroup.blocksRaycasts = true;
			*/

			Studio110Utils.UIUtilites.TogglePanels(ref startText, ref startMenu);
		}
    }
}
