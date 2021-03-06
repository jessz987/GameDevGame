﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sign3Controller : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D coll)
    {

        PlayerController p = coll.gameObject.GetComponent<PlayerController>();
        if (p != null)
        {
            Debug.Log("door");

            if (SceneManage.previousScene == "Forest1")
            {
                Vector3 pos = GameObject.Find("Player").transform.position;
                pos = new Vector3(-7.5f, -3.65f, 0);
                GameObject.Find("Player").transform.position = pos;
            }

            SceneManage.previousScene = "Market";
            SceneManager.LoadScene("Forest1");
        }
    }
}
