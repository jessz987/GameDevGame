using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGrapeController : MonoBehaviour {

    Text numGrapes;
    int totalGrapes;

    private void Start()
    {
        totalGrapes = GameManager.numGrapes + GameManager.numWine * 15;
    }

    void Update()
    {
        numGrapes = GetComponent<Text>();
        numGrapes.text = totalGrapes.ToString();
    }
}
