using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

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

    public float healthCoolDown = 2f;
    public float currentHealthCoolDownTime = 0;
    public bool invulnerable = false;

    public float weaponCoolDown = 0.5f;
    public float currentWeaponCoolDown = 0;
    public bool weaponCoolingDown = false;

    Vector2 moveDirection = Vector2.zero;

    public Animator anim;
    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    DialogueManager dialogueManager;

    public AudioSource ASplayer;
    public AudioClip attackSound;
    public AudioClip jumpSound;
    public AudioClip damageTakenSound;
    public AudioClip healthSound;

    void Start()
    {
        if (GameManager.health != 0)
        {
            lives = GameManager.health;
        }

        GameManager.health = lives;
        rb = GetComponent<Rigidbody2D>();
        dialogueManager = GetComponent<DialogueManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        updateHealthUI();

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Market")
        {
            lives = 5;
            GameManager.health = lives;
            updateHealthUI();
        }

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

    void Update()
    {
        currentHealthCoolDownTime -= Time.deltaTime;
        currentWeaponCoolDown -= Time.deltaTime;

        if (currentHealthCoolDownTime < 0)
        {
            currentHealthCoolDownTime = 0;
            Debug.Log("not invulnerable");
            invulnerable = false;
        }

        if (currentWeaponCoolDown < 0)
        {
            currentWeaponCoolDown = 0;
            Debug.Log("weapon ready");
            weaponCoolingDown = false;
        }


        moveDirection *= 0.75f;

        anim.SetBool("moving", false);
        

        if (Input.GetKey(rightKey))
        {
            moveDirection += Vector2.right;

            lastKeyLeft = false;

            anim.SetBool("moving", true);
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(leftKey))
        {
            moveDirection += Vector2.left;
            lastKeyLeft = true;
            anim.SetBool("moving", true);
            spriteRenderer.flipX = true;
        }
        else if (lastKeyLeft)
        {
            spriteRenderer.flipX = true;
        }
        


        if (Input.GetKeyDown(jumpKey) && OnGround)
        {
            ASplayer.pitch = (Random.Range(0.8f, 1.0f));
            ASplayer.PlayOneShot(jumpSound);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(attackKey) && weaponCoolingDown == false)
        {
            weaponCoolingDown = true;
            currentWeaponCoolDown = weaponCoolDown;

            anim.SetTrigger("attacking");
            anim.SetBool("moving", false);

            GameObject weapon = Instantiate(weaponPrefab);
            Vector3 newPos = weapon.transform.position;

            ASplayer.pitch = (Random.Range(0.8f, 1.0f));
            ASplayer.PlayOneShot(attackSound);

            if (lastKeyLeft)
            {
                newPos.x = transform.position.x - 0.8f;
            }
            else
                newPos.x = transform.position.x + 0.8f;

            newPos.y = transform.position.y;
            weapon.transform.position = newPos;
        }


        updateHealthUI();

    }


    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * speed * Time.deltaTime, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Health")
        {
            lives++;
            GameManager.health = lives;
            ASplayer.pitch = (Random.Range(0.8f, 1.0f));
            ASplayer.PlayOneShot(healthSound);
            updateHealthUI();
        }

        if (collision.gameObject.tag == "Stinger")
        {
            Debug.Log("hit stinger");

            if (invulnerable == false)
            {
                lives--;
                ASplayer.pitch = (Random.Range(0.8f, 1.0f));
                ASplayer.PlayOneShot(damageTakenSound);
                GameManager.health = lives;
                Debug.Log("lives left: " + lives);
                invulnerable = true;
                currentHealthCoolDownTime = healthCoolDown;

                updateHealthUI();

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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            Debug.Log("in npc trigger");
        }
        if (Input.GetKeyDown(interactKey))
        {
            if (collision.gameObject.tag == "NPC")
            {
                if (dialogueManager.InConversation)
                {
                    Debug.Log("INTERACTING AT TIME: " + Time.time);
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
            Debug.Log("exiting npc trigger");
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
            Debug.Log("touched enemy" + "Invulnerable = " + invulnerable);

            if (invulnerable == false)
            {
                lives--;
                ASplayer.pitch = (Random.Range(0.8f, 1.0f));
                ASplayer.PlayOneShot(damageTakenSound);
                GameManager.health = lives;
                Debug.Log("lives left: " + lives);
                invulnerable = true;
                currentHealthCoolDownTime = healthCoolDown;

                updateHealthUI();

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
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            OnGround = false;
        }
    }

    void updateHealthUI()
    {
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

    }
}
