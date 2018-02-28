using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinFlowerController : MonoBehaviour {

    Text numFlowers;
    int totalFlowers;

    private void Start()
    {
        totalFlowers = GameManager.numFlowers + GameManager.numBouquet * 20;
    }

    void Update()
    {
        numFlowers = GetComponent<Text>();
        numFlowers.text = totalFlowers.ToString();
    }
}
