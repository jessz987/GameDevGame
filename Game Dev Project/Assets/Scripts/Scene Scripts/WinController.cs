using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour {

    public GameObject wool;
    public GameObject catnip;
    public GameObject flower;
    public GameObject grape;

    int numberWool;
    int numberCatnip;
    int numberFlower;
    int numberGrape;

    private void Start()
    {
        numberWool = GameManager.numWool + GameManager.numYarn * 10;
        Debug.Log("you retrieved" + numberWool + " wool");
        numberCatnip = GameManager.numCatnip + GameManager.numWine * 15;
        Debug.Log("you retrieved" + numberCatnip + " catnip");
        numberGrape = GameManager.numGrapes + GameManager.numWine * 15;
        Debug.Log("you retrieved" + numberGrape + " grapes");
        numberFlower = GameManager.numFlowers + GameManager.numBouquet * 20;
        Debug.Log("you retrieved" + numberFlower + " flowers");
    }


    void Update () {
		for (int i = 0; i < numberWool; i++)
        {
            Debug.Log("spawn wool: " + numberWool);
            GameObject spawnWool = Instantiate(wool);
            Vector3 newPos = spawnWool.transform.position;
            newPos.x = -6f;
            newPos.y = 3.5f;
            spawnWool.transform.position = newPos;
        }
        for (int i = 0; i < numberCatnip; i++)
        {
            Debug.Log("spawn catnip: " + numberCatnip);
            GameObject spawnCatnip = Instantiate(catnip);
            Vector3 newPos = spawnCatnip.transform.position;
            newPos.x = -2f;
            newPos.y = 3.5f;
            spawnCatnip.transform.position = newPos;
        }
        for (int i = 0; i < numberFlower; i++)
        {
            Debug.Log("spawn flowers: " + numberFlower);
            GameObject spawnFlowers = Instantiate(flower);
            Vector3 newPos = spawnFlowers.transform.position;
            newPos.x = 6f;
            newPos.y = 3.5f;
            spawnFlowers.transform.position = newPos;
        }
        for (int i = 0; i < numberGrape; i++)
        {
            Debug.Log("spawn grapes: " + numberGrape);
            GameObject spawnGrapes = Instantiate(grape);
            Vector3 newPos = spawnGrapes.transform.position;
            newPos.x = 2f;
            newPos.y = 3.5f;
            spawnGrapes.transform.position = newPos;
        }
    }
}
