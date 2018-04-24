using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerNPCController : MonoBehaviour {

    public GameObject bouquetPrefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (GameManager.numFlowers >= 20)
            {
                GameManager.gotBouquet = true;
                Debug.Log("trade flowers for bouquet");
                GameManager.numFlowers -= 20;
                GameManager.numBouquet++;

                GameObject bouquet = Instantiate(bouquetPrefab);
                Vector3 newPos = bouquet.transform.position;
                newPos.x = -0.7f;
                newPos.y = -1.7f;
                bouquet.transform.position = newPos;
            }
        }
    }
}
