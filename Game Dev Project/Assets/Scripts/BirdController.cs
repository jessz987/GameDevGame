using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    public int health;
    
	void Start () {
        health = 2;
	}
	
	void Update () {
		if (health <= 0)
        {
            gameObject.SetActive(false);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            health--;
            Debug.Log("bird has " + health + " health left");
        }
    }
}
