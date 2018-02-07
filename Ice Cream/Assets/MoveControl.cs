using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour {

    public KeyCode rightKey;
    public KeyCode leftKey; //can be changed in the inspector

    public float speed;

    Vector2 moveDirection = Vector2.zero; //instead of new Vector2(0,0);

    Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        moveDirection *= 0.8f; //gradually slows down

		if (Input.GetKey(rightKey))
        {
            moveDirection += Vector2.right;
        }

        if (Input.GetKey(leftKey))
        {
            moveDirection += Vector2.left;
        }
	}

    void FixedUpdate()
    {
        /*
        Vector2 newVect = new Vector2(10, 283);
        newVect = newVect.normalize;
        newVect.Normalize();
        */


        Vector2 position = (Vector2)transform.position + (moveDirection * speed * Time.fixedDeltaTime);
        rb.MovePosition(position);
    }
}
