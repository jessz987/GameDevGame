using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGrapeController : MonoBehaviour {

    TextMesh numGrapes;
    int totalGrapes;

    void Start()
    {
        totalGrapes = GameManager.numGrapes + GameManager.numWine * 15;
    }

    void Update()
    {
        numGrapes = GetComponent<TextMesh>();
        numGrapes.text = totalGrapes.ToString();
    }
}
