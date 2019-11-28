using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDestroy : MonoBehaviour
{
	public float destoryTimer;

    // Start is called before the first frame update
    void Start()
    {
		Destroy(gameObject, destoryTimer);
    }

}
