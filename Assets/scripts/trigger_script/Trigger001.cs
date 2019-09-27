using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger001 : TriggerBase
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            MainUIController.instance.SetText("It's going to take me too long to run and get help. They could be in danger. I should see if I can find any clues at the campsite.", 4.0f);
        }
    }
}
