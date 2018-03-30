using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour {
    
    public AudioClip pickUpSound;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Sound.me.PlaySound(pickUpSound);
            gameObject.SetActive(false);
            GameManager.numFlowers++;
            Debug.Log(GameManager.numFlowers + " flower");
        }
    }
}
