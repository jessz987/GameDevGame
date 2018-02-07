using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopCollision : MonoBehaviour {

    GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerControl>() ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "scoop" && transform.position.y > gameManager.topScoop.transform.position.y)
        {
            //gameObject.GetComponent<Rigidbody2D>().isKinematic = true; //Kinematic means it doesn't act under physics

            Destroy(GetComponent<Rigidbody2D>());
            transform.SetParent(gameManager.cone.transform); //becomes a child so that it will move with the cone

            gameManager.topScoop = gameObject;
            gameManager.score++;
        }
    }
}
