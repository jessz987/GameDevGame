using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatnipText : MonoBehaviour {

    Text numCatnip;

    void Update()
    {
        numCatnip = GetComponent<Text>();
        numCatnip.text = GameManager.numCatnip.ToString();
    }
}
