using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoolController : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GameManager.numWool++;
            Debug.Log(GameManager.numWool + " wool");
        }
    }
}
