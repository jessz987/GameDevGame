using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YarnTextController : MonoBehaviour {

    Text numYarn;

    void Update()
    {
        numYarn = GetComponent<Text>();
        numYarn.text = GameManager.numYarn.ToString();
    }
}
