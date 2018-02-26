using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinWoolController : MonoBehaviour {

    Text numWool;
    int totalWool;

    private void Start()
    {
        totalWool = GameManager.numWool + GameManager.numYarn * 10;
    }

    void Update()
    {
        numWool = GetComponent<Text>();
        numWool.text = totalWool.ToString();
    }
}
