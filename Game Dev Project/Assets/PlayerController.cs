using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode jumpKey;
    public KeyCode interactKey;
    public KeyCode attackKey;

    public float speed;

    Vector2 moveDirection = Vector2.zero;

    Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        moveDirection *= 0.8f;
        
        if (Input.GetKey(rightKey))
        {
            moveDirection += Vector2.right;
        }

        if (Input.GetKey(leftKey))
        {
            moveDirection += Vector2.left;
        }

        if (Input.GetKey(jumpKey))
         {
            moveDirection += Vector2.up;
         }
        
        //add interactKey and attackKey code
    }
    void FixedUpdate()
    {
        Vector2 position = (Vector2)transform.position + (moveDirection * speed * Time.fixedDeltaTime);
        rb.MovePosition(position);
    }
}
