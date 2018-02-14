using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    float timeToDeath = 0.5f;

    void Update () {
        timeToDeath -= Time.deltaTime;
        if (timeToDeath <= 0)
        {
            Destroy(gameObject);
        }
	}
}
