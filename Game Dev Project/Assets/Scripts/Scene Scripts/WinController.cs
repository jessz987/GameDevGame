using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour {

    public GameObject wool;
    public GameObject catnip;
    public GameObject flower;
    public GameObject grape;
    	

	void Update () {
		for (int i = 0; i <= GameManager.numWool; i++)
        {
            GameObject spawnWool = Instantiate(wool);
            Vector3 newPos = spawnWool.transform.position;
            newPos.x = -6f;
            newPos.y = 3.5f;
            spawnWool.transform.position = newPos;
        }
        for (int i = 0; i <= GameManager.numCatnip; i++)
        {
            GameObject spawnCatnip = Instantiate(catnip);
            Vector3 newPos = spawnCatnip.transform.position;
            newPos.x = -2f;
            newPos.y = 3.5f;
            spawnCatnip.transform.position = newPos;
        }
        for (int i = 0; i <= GameManager.numFlowers; i++)
        {
            GameObject spawnFlowers = Instantiate(flower);
            Vector3 newPos = spawnFlowers.transform.position;
            newPos.x = 6f;
            newPos.y = 3.5f;
            spawnFlowers.transform.position = newPos;
        }
        for (int i = 0; i <= GameManager.numGrapes; i++)
        {
            GameObject spawnGrapes = Instantiate(grape);
            Vector3 newPos = spawnGrapes.transform.position;
            newPos.x = 2f;
            newPos.y = 3.5f;
            spawnGrapes.transform.position = newPos;
        }
    }
}
