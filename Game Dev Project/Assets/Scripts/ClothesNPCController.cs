using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesNPCController : MonoBehaviour {

    public GameObject yarnPrefab;

    public GameObject textbox;
    private GameObject textBoxClone;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textBoxClone = Instantiate(textbox);
            Vector3 boxPos = textbox.transform.position;
            boxPos.x = 8f;
            boxPos.y = -2f; ;
            textbox.transform.position = boxPos;

            if (GameManager.numWool >= 10)
            {
                GameManager.gotYarn = true;
                Debug.Log("trade wool for yarn");
                GameManager.numWool -= 10;
                GameManager.numYarn++;

                GameObject yarn = Instantiate(yarnPrefab);
                Vector3 newPos = yarn.transform.position;
                newPos.x = 8.5f;
                newPos.y = -1.7f;
                yarn.transform.position = newPos;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(textBoxClone);
    }
}
