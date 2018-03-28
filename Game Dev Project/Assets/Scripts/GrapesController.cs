using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapesController : MonoBehaviour {

    public AudioSource ASplayer;
    public AudioClip pickUpSound;

    void OnCollisionEnter2D(Collision2D coll)
    {
        ASplayer.PlayOneShot(pickUpSound);
        if (coll.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GameManager.numGrapes++;
            Debug.Log(GameManager.numGrapes + " grapes");
        }
    }
}
