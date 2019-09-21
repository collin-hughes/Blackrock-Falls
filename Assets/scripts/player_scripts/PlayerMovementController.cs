using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;

    private Vector2 moveInput;
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
        if (playerStatus.isSprinting)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal") * sprintSpeed, Input.GetAxisRaw("Vertical") * sprintSpeed);
        }

        else
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + moveInput);
    }
}
