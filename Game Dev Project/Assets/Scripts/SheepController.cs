using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour {
    
    public Transform[] patrolPositions;
    public float speed;

    public Animator anim;
    public string currentAnim;

    void Update()
    {
        anim = GetComponent<Animator>();
        currentAnim = "SheepLeft";
        

        Patrol();
    }
    
    void Patrol()
    {
        transform.position = Vector3.Lerp(patrolPositions[0].position, patrolPositions[1].position, Mathf.PingPong(Time.time * speed, 1f));
        if (transform.position.x >= patrolPositions[1].position.x - 0.01f)
        {
            anim.SetBool("ToRight", false);
        }

        if (transform.position.x <= patrolPositions[0].position.x + 0.01f)
        {
            anim.SetBool("ToRight", true);
        }
    }
}
