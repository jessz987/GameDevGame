using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YarnUIController : MonoBehaviour {

    public GameObject yarn;

    void Update()
    {
        if (GameManager.gotYarn)
        {
            yarn.SetActive(true);
        }
    }
}
