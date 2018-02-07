using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GameManager.numFlowers++;
            Debug.Log(GameManager.numFlowers + " flower");
        }
    }
}
