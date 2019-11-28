using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ch_1_sc_1_tr_01 : TriggerBase
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            MainUIController.instance.SetText("It's going to take me too long to run and get help. They could be in danger. I should see if I can find any clues at the campsite.", 4.0f);
        }
    }
}
