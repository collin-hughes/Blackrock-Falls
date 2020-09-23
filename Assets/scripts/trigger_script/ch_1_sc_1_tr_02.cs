using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ch_1_sc_1_tr_02 : TriggerBase
{
	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			LoadingController.instance.LoadScene(2);
		}
	}
}
