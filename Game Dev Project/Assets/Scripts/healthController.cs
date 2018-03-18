using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (GameManager.health < 5)
            {
                gameObject.SetActive(false);
                Debug.Log("health +1");
            }
        }
    }
}
