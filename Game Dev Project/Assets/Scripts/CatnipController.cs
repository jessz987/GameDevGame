using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatnipController : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GameManager.numCatnip++;
            Debug.Log(GameManager .numCatnip + " catnip");
        }
    }
}
