using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoolTextController : MonoBehaviour {

    Text wool;

    void Update()
    {
        wool = GetComponent<Text>();
        wool.text = GameManager.numWool.ToString();
    }
}
