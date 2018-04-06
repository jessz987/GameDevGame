using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCatnipController : MonoBehaviour {

    TextMesh numCatnip;
    int totalCatnip;

    void Start()
    {
        totalCatnip = GameManager.numCatnip + GameManager.numWine * 15;
    }

    void Update()
    {
        numCatnip = GetComponent<TextMesh>();
        numCatnip.text = totalCatnip.ToString();
    }
}
