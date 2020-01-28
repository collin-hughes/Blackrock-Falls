using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
	[SerializeField] private Animator playerAnimator;
	[SerializeField] private GameObject playerLegs;

    private Vector2 moveInput;
	private Controls input;
    private Rigidbody2D rigidbody;

    private PlayerStatusController playerStatus;

	// Start is called before the first frame update
	void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        playerStatus = GetComponent<PlayerStatusController>();
    }

    // Update is called once per frame
    void Update()
    {
		if (GameState.playing == GameController.instance.GetCurrentState())
		{
			if (playerStatus.isSprinting)
			{
				moveInput = new Vector2(Input.GetAxisRaw("Horizontal") * sprintSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * sprintSpeed * Time.deltaTime);

				if(moveInput.x != 0 || moveInput.y != 0)
				{
					playerAnimator.SetInteger("state", 2);
				}	
			}

			else
			{
				moveInput = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime);

				if (moveInput.x != 0 || moveInput.y != 0)
				{
					playerAnimator.SetInteger("state", 1);
				}

				else
				{
					playerAnimator.SetInteger("state", 0);
				}
			}
		}

		if((moveInput.x > 0 && moveInput.y > 0) || (moveInput.x < 0 && moveInput.y < 0))
		{
			playerLegs.transform.eulerAngles = new Vector3(0, 0, -45);
		}

		else if ((moveInput.x < 0 && moveInput.y > 0) || (moveInput.x > 0 && moveInput.y < 0))
		{
			playerLegs.transform.eulerAngles = new Vector3(0, 0, 45);
		}

		else if (moveInput.x != 0)
		{
			playerLegs.transform.eulerAngles = new Vector3(0, 0, -90);
		}

		else if (moveInput.y != 0)
		{
			playerLegs.transform.eulerAngles = new Vector3(0, 0, 0);
		}
	}

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + moveInput);
    }
}
