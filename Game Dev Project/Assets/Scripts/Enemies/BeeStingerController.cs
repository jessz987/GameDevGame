using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeStingerController : MonoBehaviour
{

    public float timeTillDeath;

    void Update()
    {
        timeTillDeath -= Time.deltaTime;
        if (timeTillDeath <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.health--;
        }
    }
}
