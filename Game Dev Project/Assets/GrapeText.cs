using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrapeText : MonoBehaviour {

    Text numGrapes;
    

	void Update () {
        numGrapes = GetComponent<Text>();
        numGrapes.text = GameManager.numGrapes.ToString();
    }
}
