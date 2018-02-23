using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouquetTextController : MonoBehaviour {

    Text numBouquet;

    void Update()
    {
        numBouquet = GetComponent<Text>();
        numBouquet.text = GameManager.numBouquet.ToString();
    }
}
