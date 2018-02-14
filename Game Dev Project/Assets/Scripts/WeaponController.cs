using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    float timeToDeath = 0.2f;

    public GameObject woolPrefab;

    void Update () {
        timeToDeath -= Time.deltaTime;
        if (timeToDeath <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sheep")
        {
            GameObject wool = Instantiate(woolPrefab);
            Vector3 newPos = wool.transform.position;

            newPos = transform.position;


            wool.transform.position = newPos;
        }
    }    
}
