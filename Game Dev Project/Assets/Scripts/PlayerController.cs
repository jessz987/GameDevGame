using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode jumpKey;
    public KeyCode interactKey;
    public KeyCode attackKey;

    public Image[] healthSpots;
    public GameObject weaponPrefab;

    public float speed;
    public bool OnGround = false;
    public float jumpForce = 100f;
    public int lives = 5;

    Vector2 moveDirection = Vector2.zero;

    Rigidbody2D rb;

	void Start () {
        GameManager.health = lives;
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
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

        if (Input.GetKeyDown(attackKey))
        {
            GameObject weapon = Instantiate(weaponPrefab);
            Vector3 newPos = weapon.transform.position;
            newPos.x = transform.position.x -0.6f;
            newPos.y = transform.position.y;
            weapon.transform.position = newPos;
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
            lives--;
            GameManager.health = lives;
            Debug.Log("lives left: " + lives);

            switch (lives)
            {
                case 5:
                    for (int i = 0; i < healthSpots.Length; i++)
                    {
                        healthSpots[i].gameObject.SetActive(true);
                    }
                    break;
                case 4:
                    for (int i = 0; i < healthSpots.Length; i++)
                    {
                        healthSpots[i].gameObject.SetActive(true);
                        if (i == 4)
                        {
                            healthSpots[i].gameObject.SetActive(false);
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < healthSpots.Length; i++)
                    {
                        healthSpots[i].gameObject.SetActive(true);
                        if (i == 3 || i == 4)
                        {
                            healthSpots[i].gameObject.SetActive(false);
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < healthSpots.Length; i++)
                    {
                        healthSpots[i].gameObject.SetActive(true);
                        if (i == 2 || i == 3 || i == 4)
                        {
                            healthSpots[i].gameObject.SetActive(false);
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < healthSpots.Length; i++)
                    {
                        healthSpots[i].gameObject.SetActive(true);
                        if (i != 0)
                        {
                            healthSpots[i].gameObject.SetActive(false);
                        }
                    }
                    break;
                case 0:
                    for (int i = 0; i < healthSpots.Length; i++)
                    {
                        healthSpots[i].gameObject.SetActive(false);
                    }
                    break;
            }

            if (lives <= 0)
            {
                Debug.Log("game over");
                SceneManager.LoadScene("GameOver");
            }

            
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
