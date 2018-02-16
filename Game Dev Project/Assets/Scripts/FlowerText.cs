using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerText : MonoBehaviour {

    Text numFlowers;

    void Update()
    {
        numFlowers = GetComponent<Text>();
        numFlowers.text = GameManager.numFlowers.ToString();
    }
}
