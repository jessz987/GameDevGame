using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    public int health;
    public Transform[] patrolPositions;
    public float speed;

    public Animator anim;

    void Start () {
        health = 2;
    }
	
	void Update () {
        anim = GetComponent<Animator>();
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        Patrol();
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            health--;
            Debug.Log("bird has " + health + " health left");
        }
    }

    void Patrol ()
    {
        transform.position = Vector3.Lerp(patrolPositions[0].position, patrolPositions[1].position, Mathf.PingPong(Time.time * speed, 1f));

        if (transform.position.x >= patrolPositions[1].position.x - 0.1f)
        {
            Debug.Log("moving left");
            anim.SetBool("moveLeft", true);
        }

        if (transform.position.x <= patrolPositions[0].position.x + 0.1f)
        {
            Debug.Log("moving right");
            anim.SetBool("moveLeft", false);
        }
    }
}
