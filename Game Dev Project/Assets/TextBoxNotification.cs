using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxNotification : MonoBehaviour
{

    public GameObject textBox;

    void Start()
    {
        textBox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textBox.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textBox.SetActive(false);
        }
    }
}