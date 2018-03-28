using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapesController : MonoBehaviour {

    public AudioSource ASplayer;
    public AudioClip pickUpSound;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            ASplayer.PlayOneShot(pickUpSound);
            gameObject.SetActive(false);
            GameManager.numGrapes++;
            Debug.Log(GameManager.numGrapes + " grapes");
        }
    }
}
