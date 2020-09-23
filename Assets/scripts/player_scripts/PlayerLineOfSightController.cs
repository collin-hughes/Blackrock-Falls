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

	[SerializeField] private PlayerFieldOfViewController fovForward;
	[SerializeField] private PlayerFieldOfViewController fovPeripheral;

	public void Start()
	{
		//PlayerInventoryController.instance.equipedLight.GetLightingMaterial();
	}

	public void SetMaterial(Material lightingMaterial)
    {
		fovForward.SetMaterial(lightingMaterial);
		fovPeripheral.SetMaterial(lightingMaterial);

	}
}
