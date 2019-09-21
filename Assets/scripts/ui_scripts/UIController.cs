using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject followTarget;


    private TextMeshProUGUI textbox;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followTarget.transform.position;
    }

    public void SetText(string text)
    {
        textbox.CrossFadeAlpha(1.0f, 0.0f, false);
        textbox.SetText(text);
        textbox.CrossFadeAlpha(0.0f, 5f, false);
    }
}
