using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    public int health;
    public Transform[] patrolPositions;
    public float speed;

    public bool faceLeft;

    public Animator anim;
    SpriteRenderer sr;

    public AudioSource ASplayer;
    public AudioClip hitSound;

    void Start () {
        health = 2;
        sr = GetComponent<SpriteRenderer>();
    }
	
	void Update () {
        anim = GetComponent<Animator>();
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        Patrol();

        if (faceLeft)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            ASplayer.PlayOneShot(hitSound);
            health--;
            Debug.Log("bird has " + health + " health left");
        }
    }

    void Patrol ()
    {
        Vector3 newPos = Vector3.Lerp(patrolPositions[0].position, patrolPositions[1].position, Mathf.PingPong(Time.time * speed, 1f));

        Vector3 direction = newPos - transform.position;

        if (Mathf.Sign(direction.x) > 0)
        {
            anim.SetBool("moveLeft", false);
            faceLeft = false;
        }
        else
        {
            anim.SetBool("moveLeft", true);
            faceLeft = true;
        }

        transform.position = newPos;
    }
}
