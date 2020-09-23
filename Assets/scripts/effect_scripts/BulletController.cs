using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
	private Vector2 startingPosition;

    private Rigidbody2D rb2d;
    //Transform endPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        Destroy(gameObject, 2f);

		startingPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		rb2d.MovePosition(transform.position + transform.up * moveSpeed);
		
		if(Vector2.Distance(transform.position, startingPosition) > PlayerInventoryController.instance.equipedWeapon.range)
		{
			Destroy(gameObject);
		}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
		//Debug.Log(collision.transform.name);
        Destroy(gameObject);
    }
}
