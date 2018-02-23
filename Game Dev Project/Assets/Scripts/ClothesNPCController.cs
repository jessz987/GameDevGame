using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesNPCController : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.numWool >= 10)
            {
                Debug.Log("trade wool for yarn");
                GameManager.numWool -= 10;
                GameManager.numYarn++;
            }
        }
    }
}
