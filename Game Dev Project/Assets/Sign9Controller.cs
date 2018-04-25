using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sign9Controller : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D coll)
    {

        PlayerController p = coll.gameObject.GetComponent<PlayerController>();
        if (p != null)
        {
            SceneManage.previousScene = "Forest1.5";
            SceneManager.LoadScene("Forest1");
        }
    }
}
