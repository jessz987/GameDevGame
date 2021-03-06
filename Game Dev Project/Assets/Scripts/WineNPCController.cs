﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineNPCController : MonoBehaviour {

    public GameObject winePrefab;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (GameManager.numCatnip >= 15 && GameManager.numGrapes >= 15)
            {
                GameManager.gotWine = true;
                GameManager.numGrapes -= 15;
                GameManager.numCatnip -= 15;
                GameManager.numWine++;

                GameObject wine = Instantiate(winePrefab);
                Vector3 newPos = wine.transform.position;
                newPos.x = -5.35f;
                newPos.y = -1.5f;
                wine.transform.position = newPos;
            }
        }
    }
}
