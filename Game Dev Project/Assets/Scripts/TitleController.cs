using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Tutorial");

            GameManager.health = 5;
            GameManager.numWool = 0;
            GameManager.numFlowers = 0;
            GameManager.numCatnip = 0;
            GameManager.numGrapes = 0;
        }
    }
}
