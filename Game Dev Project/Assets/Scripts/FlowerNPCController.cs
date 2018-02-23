using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerNPCController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.numFlowers >= 20)
            {
                Debug.Log("trade flowers for bouquet");
                GameManager.numFlowers -= 20;
                GameManager.numBouquet++;
            }
        }
    }
}
