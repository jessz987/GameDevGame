using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WineTextController : MonoBehaviour {

    Text numWine;

    void Update()
    {
        numWine = GetComponent<Text>();
        numWine.text = GameManager.numWine.ToString();
    }
}
