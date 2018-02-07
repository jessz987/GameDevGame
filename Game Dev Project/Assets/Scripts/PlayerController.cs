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
            //moveDirection += Vector2.up;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("jump");
        }
        
        //add interactKey and attackKey code
    }
    void FixedUpdate()
    {
        //Vector2 position = (Vector2)transform.position + (moveDirection * speed * Time.fixedDeltaTime);
        //rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + moveDirection * speed * Time.deltaTime);
        rb.velocity = new Vector3(moveDirection.x * speed * Time.deltaTime, rb.velocity.y);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            OnGround = true;
            Debug.Log("on ground");
        }

        /*
        if (collision.gameObject.tag == "Sheep")
        {
            GameManager.numWool++;
            Debug.Log("wool");
        }

        if (collision.gameObject.tag == "Catnip")
        {
            GameManager.numCatnip++;
            Debug.Log("catnip");
        }

        if (collision.gameObject.tag == "Flower")
        {
            GameManager.numFlowers++;
            Debug.Log("flower");
        }

        if (collision.gameObject.tag == "Grapes")
        {
            GameManager.numGrapes++;
            Debug.Log("grapes");
        }
        */

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            OnGround = false;
            Debug.Log("not on ground");
        }
    }

}
