using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoolController : MonoBehaviour {

    public AudioSource ASplayer;
    public AudioClip pickUpSound;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            ASplayer.PlayOneShot(pickUpSound);
            gameObject.SetActive(false);
            GameManager.numWool++;
            Debug.Log(GameManager.numWool + " wool");
        }
    }
}
