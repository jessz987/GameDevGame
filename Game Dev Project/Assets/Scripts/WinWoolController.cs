using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinWoolController : MonoBehaviour {

    TextMesh numWool;
    int totalWool;

    void Start()
    {
        totalWool = GameManager.numWool + GameManager.numYarn * 10;
    }

    void Update()
    {
        numWool = GetComponent<TextMesh>();
        numWool.text = totalWool.ToString();
    }
}
