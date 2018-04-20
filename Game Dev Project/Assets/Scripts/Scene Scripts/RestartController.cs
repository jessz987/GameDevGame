using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartController : MonoBehaviour {

    public KeyCode restart;
    
	void Update () {
        if (Input.GetKeyDown(restart))
        {
            SceneManager.LoadScene("Rooftop");

            GameManager.health = 5;
            GameManager.numWool = 0;
            GameManager.numFlowers = 0;
            GameManager.numCatnip = 0;
            GameManager.numGrapes = 0;
        }
	}
}
