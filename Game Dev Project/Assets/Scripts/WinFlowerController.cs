using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinFlowerController : MonoBehaviour {

    TextMesh numFlowers;
    int totalFlowers;

    void Start()
    {
        totalFlowers = GameManager.numFlowers + GameManager.numBouquet * 20;
    }

    void Update()
    {
        numFlowers = GetComponent<TextMesh>();
        numFlowers.text = totalFlowers.ToString();
    }
}
