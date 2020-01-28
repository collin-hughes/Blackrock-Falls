using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLineOfSightController : MonoBehaviour
{
    #region Singleton
    public static PlayerLineOfSightController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of LineOfSight found!");
        }

        instance = this;
    }
    #endregion

    [SerializeField] private Light2D forwardLineOfSight;
    [SerializeField] private Light2D peripheralLineOfSight;

    [SerializeField] private float baseIntensity;

    public void SetIntensity(float intensityMultiplier)
    {
        forwardLineOfSight.intensity = baseIntensity * intensityMultiplier;
        peripheralLineOfSight.intensity = baseIntensity * intensityMultiplier;
    }
}
