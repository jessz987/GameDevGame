using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineNPCController : MonoBehaviour {

    public GameObject winePrefab;

    public GameObject textbox;
    private GameObject textBoxClone;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textBoxClone = Instantiate(textbox);
            Vector3 boxPos = textbox.transform.position;
            boxPos.x = -6f;
            boxPos.y = -2f; ;
            textbox.transform.position = boxPos;

            if (GameManager.numCatnip >= 15 && GameManager.numGrapes >= 15)
            {
                GameManager.gotWine = true;
                Debug.Log("trade for wine");
                GameManager.numGrapes -= 15;
                GameManager.numCatnip -= 15;
                GameManager.numWine++;

                GameObject wine = Instantiate(winePrefab);
                Vector3 newPos = wine.transform.position;
                newPos.x = -5.35f;
                newPos.y = -1.5f;
                wine.transform.position = newPos;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(textBoxClone);
    }
}
