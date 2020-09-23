using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Experimental.Rendering.Universal;

public class LightingUtils : MonoBehaviour
{
    [SerializeField] private float minFlicker;
    [SerializeField] private float maxFlicker;
    [SerializeField] private float rateDampening;

	private EnvironmentalLight lightSource;

	private float intensity;

    // Start is called before the first frame update
    void Start()
    {
        lightSource = GetComponent<EnvironmentalLight>();

        StartCoroutine(DoFlicker());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DoFlicker()
    {
        while(true)
        {
            lightSource.viewDistance = Random.Range(minFlicker, maxFlicker);

            yield return new WaitForSeconds(rateDampening);
        }

    }
}
