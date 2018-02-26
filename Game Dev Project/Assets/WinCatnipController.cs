using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCatnipController : MonoBehaviour {

    Text numCatnip;
    int totalCatnip;

    private void Start()
    {
        totalCatnip = GameManager.numCatnip + GameManager.numWine * 15;
    }

    void Update()
    {
        numCatnip = GetComponent<Text>();
        numCatnip.text = totalCatnip.ToString();
    }
}
