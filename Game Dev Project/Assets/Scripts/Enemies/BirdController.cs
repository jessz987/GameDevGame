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
    
    public AudioClip hitSound;

    float stunTimer = 0;
    float stunDuration = 2f;

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
            anim.SetTrigger("hurt");
            Sound.me.PlaySoundJitter(hitSound, 1f, 0.2f, 1.3f, 0.5f);
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
            faceLeft = false;
        }
        else
        {
            faceLeft = true;
        }

        transform.position = newPos;
    }
}
