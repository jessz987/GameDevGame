using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouquetUIController : MonoBehaviour {

    public GameObject bouquet;

    void Update()
    {
        if (GameManager.gotBouquet)
        {
            bouquet.SetActive(true);
        }
    }
}
