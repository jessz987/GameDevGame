using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour {

    public int health;
    public Transform[] patrolPositions;
    public float speed;

    public GameObject weapon;
    public float spawnWeapon = 1.5f;
    private float currentSpawnWeaponTimer = 0;
    public bool spawnWeaponLeft;

    Vector2 shootDirection;

    void Start()
    {
        health = 3;
        spawnWeaponLeft = false;
        currentSpawnWeaponTimer = spawnWeapon;
    }

    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        Patrol();

        currentSpawnWeaponTimer -= Time.deltaTime;

        if (currentSpawnWeaponTimer <= 0)
        {
            GameObject stinger = Instantiate(weapon);
            Vector3 newPos = stinger.transform.position;
            newPos = transform.position;
            stinger.transform.position = newPos;

            Rigidbody2D stingerBody = stinger.GetComponent<Rigidbody2D>();
            
            stingerBody.velocity = shootDirection * 5f;

            currentSpawnWeaponTimer = spawnWeapon;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            health--;
            Debug.Log("bee has " + health + " health left");
        }
    }
    
    void Patrol()
    {
        Vector3 newPos = Vector3.Lerp(patrolPositions[0].position, patrolPositions[1].position, Mathf.PingPong(Time.time * speed, 1f));

        Vector3 direction = newPos - transform.position;
        
        if (Mathf.Sign(direction.x) > 0)
        {
            shootDirection = Vector2.right;
        }
        else
        {
            shootDirection = Vector2.left;
        }

        transform.position = newPos;
    }
}
