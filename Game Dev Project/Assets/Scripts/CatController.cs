using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour {

    public GameObject textbox;

    private GameObject textBoxClone;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textBoxClone = Instantiate(textbox);
            Vector3 newPos = textbox.transform.position;
            newPos.x = 1.5f;
            newPos.y = 1.7f; ;
            textbox.transform.position = newPos;

            if (GameManager.numBouquet >= 1 && GameManager.numWine >= 1 && GameManager.numYarn >= 1)
            {
                Debug.Log("you win");
                SceneManager.LoadScene("WinScene");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(textBoxClone);
    }
}
