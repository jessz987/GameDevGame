using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sign2Controller : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {

        PlayerController p = coll.gameObject.GetComponent<PlayerController>();
        if (p != null)
        {
            Debug.Log("door");

            SceneManage.previousScene = "Market";
            SceneManager.LoadScene("Rooftop");
        }
    }
}
