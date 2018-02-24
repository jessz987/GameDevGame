using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
        
            if (GameManager.numBouquet >= 1 && GameManager.numWine >= 1 && GameManager.numYarn >= 1)
            {
                Debug.Log("you win");
                SceneManager.LoadScene("WinScene");
            }
        }
    }
}
