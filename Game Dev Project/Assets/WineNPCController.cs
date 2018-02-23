using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineNPCController : MonoBehaviour {
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.numCatnip >= 15 && GameManager.numGrapes >= 15)
            {
                Debug.Log("trade for wine");
                GameManager.numGrapes -= 15;
                GameManager.numCatnip -= 15;
                GameManager.numWine++;
            }
        }
    }
}
