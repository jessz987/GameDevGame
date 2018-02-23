using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour {

    public int health;
    public Transform[] patrolPositions;
    public float speed;

    public GameObject weapon;
    public float spawnWeapon = 1.5f;
    public bool spawnWeaponLeft;

    void Start()
    {
        health = 3;
        spawnWeaponLeft = false;
    }

    void Update()
    {
        spawnWeapon -= Time.deltaTime;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        Patrol();

        if (spawnWeapon <= 0)
        {
            GameObject stinger = Instantiate(weapon);
            Vector3 newPos = stinger.transform.position;
            newPos = transform.position;
            stinger.transform.position = newPos;

            Rigidbody2D stingerBody = stinger.GetComponent<Rigidbody2D>();

            if (spawnWeaponLeft)
            {
                stingerBody.velocity = new Vector2(-5, 0);
                spawnWeaponLeft = false;
            }

            if (spawnWeaponLeft == false)
            {
                stingerBody.velocity = new Vector2(5, 0);
                spawnWeaponLeft = true;
            }
        
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
        transform.position = Vector3.Lerp(patrolPositions[0].position, patrolPositions[1].position, Mathf.PingPong(Time.time * speed, 1f));
    }
}
