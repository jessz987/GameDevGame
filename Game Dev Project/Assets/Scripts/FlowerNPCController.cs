using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerNPCController : MonoBehaviour {

    public GameObject bouquetPrefab;

    public GameObject textbox;
    private GameObject textBoxClone;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textBoxClone = Instantiate(textbox);
            Vector3 boxPos = textbox.transform.position;
            boxPos.x = -1.3f;
            boxPos.y = -2.1f; ;
            textbox.transform.position = boxPos;

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(textBoxClone);
    }
}
