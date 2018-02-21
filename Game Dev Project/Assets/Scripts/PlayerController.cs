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

    public bool lastKeyLeft;

    public Image[] healthSpots;
    public GameObject weaponPrefab;

    public float speed;
    public bool OnGround = false;
    public float jumpForce = 100f;
    public int lives;

    Vector2 moveDirection = Vector2.zero;

    public Animator anim;
    public string currentAnim;

    Rigidbody2D rb;

    DialogueManager dialogueManager;

	void Start () {
        GameManager.health = lives;
        rb = GetComponent<Rigidbody2D>();
        dialogueManager = GetComponent<DialogueManager>();

        if (GameManager.leftSpawn == true)
        {
            Vector3 playerpos = transform.position;
            playerpos.x = -7.73f;
            playerpos.y = -3.51f;
            transform.position = playerpos;
            Debug.Log("spawned left");
        }
        if (GameManager.rightSpawn == true)
        {
            Vector3 playerpos = transform.position;
            playerpos.x = 7.73f;
            playerpos.y = -3.51f;
            transform.position = playerpos;
            Debug.Log("spawned right");
        }
        if (GameManager.rooftopSpawn == true)
        {
            Vector3 playerpos = transform.position;
            playerpos.x = 2f;
            playerpos.y = 2.4f;
            transform.position = playerpos;
            Debug.Log("spawned center");
        }
    }
	
	void Update ()
    {
        anim = GetComponent<Animator>();
        currentAnim = "rightIdle";
        moveDirection *= 0.75f;
        
        if (Input.GetKey(rightKey))
        {
            moveDirection += Vector2.right;
            lastKeyLeft = false;
            currentAnim = "moveRight";
        }
        else
        {
            currentAnim = "rightIdle";
        }

        if (Input.GetKey(leftKey))
        {
            moveDirection += Vector2.left;
            lastKeyLeft = true;
            currentAnim = "moveLeft";
        }
        else if (lastKeyLeft)
        {
            currentAnim = "leftIdle";
        }


        

        if (Input.GetKeyDown(jumpKey) && OnGround)
         {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        anim.Play(currentAnim);

        if (Input.GetKeyDown(attackKey))
        {
            GameObject weapon = Instantiate(weaponPrefab);
            Vector3 newPos = weapon.transform.position;

            if (lastKeyLeft)
            {
                newPos.x = transform.position.x - 0.8f;
            }
            else
                newPos.x = transform.position.x + 0.8f;

            newPos.y = transform.position.y;
            weapon.transform.position = newPos;
        }
        
        //add interactKey and attackKey code
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * speed * Time.deltaTime, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stinger")
        {
            lives--;
            GameManager.health = lives;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(interactKey))
        {
            if (collision.gameObject.tag == "NPC")
            {
                if (dialogueManager.InConversation)
                {
                    dialogueManager.AdvanceConversation();
                }
                else
                {
                    dialogueManager.BeginConversation(collision.gameObject);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            if (dialogueManager.InConversation)
            {
                dialogueManager.EndConversation();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            OnGround = true;
        }

        if (collision.gameObject.tag == "SpawnLeft")
        {
            GameManager.leftSpawn = true;
            GameManager.rightSpawn = false;
            GameManager.rooftopSpawn = false;
        }

        if (collision.gameObject.tag == "SpawnRight")
        {
            GameManager.rightSpawn = true;
            GameManager.leftSpawn = false;
            GameManager.rooftopSpawn = false;
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
                GameManager.leftSpawn = false;
                GameManager.rightSpawn = false;
                GameManager.rooftopSpawn = true;
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
