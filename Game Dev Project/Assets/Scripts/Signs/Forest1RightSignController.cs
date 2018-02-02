using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Forest1RightSignController : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {

        PlayerController p = coll.gameObject.GetComponent<PlayerController>();
        if (p != null)
        {
            Debug.Log("door");

            SceneManager.currentScene = "Forest1";
            SceneManager.LoadScene("Market");
        }
    }
}
