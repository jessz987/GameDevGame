using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour {
    
    public Transform[] patrolPositions;
    public float speed;

    public Animator anim;
    public string currentAnim;

    public bool faceLeft;

    public int woolLimit = 3;
    public GameObject woolPrefab;
    SpriteRenderer sr;

    public AudioSource ASplayer;
    public AudioClip hitSound;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        anim = GetComponent<Animator>();
        currentAnim = "SheepLeft";
        
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
    
    void Patrol()
    {
        Vector3 newPos = Vector3.Lerp(patrolPositions[0].position, patrolPositions[1].position, Mathf.PingPong(Time.time * speed, 1f));

        Vector3 direction = newPos - transform.position;

        if (Mathf.Sign(direction.x) > 0)
        {
            faceLeft = true;
        }
        else
        {
            faceLeft = false;
        }

        transform.position = newPos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            ASplayer.PlayOneShot(hitSound);
            woolLimit--;
            if (woolLimit >= 0)
            {
                GameObject wool = Instantiate(woolPrefab);
                Vector3 newPos = wool.transform.position;

                newPos = transform.position;

                wool.transform.position = newPos;
            }
        }
    }
}
