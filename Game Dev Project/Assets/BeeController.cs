using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour {

    public int health;

    void Start()
    {
        health = 3;
    }

    void Update()
    {
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
            Debug.Log("bee has " + health + " health left");
        }
    }
}
