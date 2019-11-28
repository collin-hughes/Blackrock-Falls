using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Studio110Utils
{
	public class UIUtilites : MonoBehaviour
	{
		public static void HidePanel(ref GameObject gameObject)
		{
			CanvasGroup canvasGroup;

			if (gameObject.GetComponent<CanvasGroup>() != null)
			{
				canvasGroup = gameObject.GetComponent<CanvasGroup>();

				canvasGroup.alpha = 0;
				canvasGroup.interactable = false;
				canvasGroup.blocksRaycasts = false;
			}
		}

		public static void ShowPanel(ref GameObject  gameObject)
		{
			CanvasGroup canvasGroup;

			if (gameObject.GetComponent<CanvasGroup>() != null)
			{
				canvasGroup = gameObject.GetComponent<CanvasGroup>();

				canvasGroup.alpha = 1;
				canvasGroup.interactable = true;
				canvasGroup.blocksRaycasts = true;
			}
		}

		public static void TogglePanels(ref GameObject disabledPanel, ref GameObject enabledPanel)
		{
			HidePanel(ref disabledPanel);
			ShowPanel(ref enabledPanel);
		}

		public static void UpdateSlider(ref Slider slider, float currentAmount, float totalAmount)
		{
			slider.value = (currentAmount / totalAmount) * slider.maxValue;
		}
	}
}

