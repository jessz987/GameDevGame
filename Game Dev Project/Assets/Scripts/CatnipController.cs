using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatnipController : MonoBehaviour {


    public AudioSource ASplayer;
    public AudioClip pickUpSound;


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            ASplayer.PlayOneShot(pickUpSound);
            gameObject.SetActive(false);
            GameManager.numCatnip++;
            Debug.Log(GameManager .numCatnip + " catnip");
        }
    }
}
