using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public KeyCode start;

    void Update()
    {
        if (Input.GetKeyDown(start))
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
