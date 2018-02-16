﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    public int health;
    public Transform[] patrolPositions;
    public float speed;
    
	void Start () {
        health = 2;
	}
	
	void Update () {
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
    }
}
