using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WineUIController : MonoBehaviour {

    public GameObject wine;

    void Update()
    {
        if (GameManager.gotWine)
        {
            wine.SetActive(true);
        }
    }
}
