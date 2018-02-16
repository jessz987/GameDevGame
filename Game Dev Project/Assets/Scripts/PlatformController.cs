using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public Transform[] patrolPositions;
    public float speed;
    
	
	void Update () {
        Patrol();
	}

    void Patrol()
    {
        transform.position = Vector3.Lerp(patrolPositions[0].position, patrolPositions[1].position, Mathf.PingPong(Time.time * speed, 1f));
    }
}
