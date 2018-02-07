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
    public bool OnGround = false;
    public float jumpForce = 100f;

    Vector2 moveDirection = Vector2.zero;

    Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        moveDirection *= 0.75f;
        
        if (Input.GetKey(rightKey))
        {
            moveDirection += Vector2.right;
        }

        if (Input.GetKey(leftKey))
        {
            moveDirection += Vector2.left;
        }

        if (Input.GetKeyDown(jumpKey) && OnGround)
         {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        //add interactKey and attackKey code
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * speed * Time.deltaTime, rb.velocity.y);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            OnGround = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.health--;
            Debug.Log("lives left: " + GameManager.health);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            OnGround = false;
        }
    }

}
