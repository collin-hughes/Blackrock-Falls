using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotationController : MonoBehaviour
{
    [SerializeField]
    private int rotationOffset;

	[SerializeField]
	private PlayerFieldOfViewController fovForward;

	[SerializeField]
	private PlayerFieldOfViewController fovPeripheral;

	// Update is called once per frame
	void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
        difference.Normalize();

		fovForward.SetAimDirection(difference);
		fovPeripheral.SetAimDirection(difference);

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - rotationOffset);
    }
}
