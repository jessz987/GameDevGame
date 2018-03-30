using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapesController : MonoBehaviour {
    
    public AudioClip pickUpSound;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Sound.me.PlaySound(pickUpSound);
            gameObject.SetActive(false);
            GameManager.numGrapes++;
            Debug.Log(GameManager.numGrapes + " grapes");
        }
    }
}
