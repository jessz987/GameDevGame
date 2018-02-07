using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float Xmax;
    public float Xmin;
    //public float Ymax;
    //public float Ymin;

    public Vector3 offset;

    public Transform player;

    private void Start()
    {
        Xmin = -3f;
        Xmax = 3f;
        //Ymin = -1.1f;
        //Ymax = 1.5f;
           
    }

    void Update()
    {
        //if (player.position.x > Xmin && player.position.x < Xmax) // && player.position.y > Ymin && player.position.y < Ymax
        //    transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, 0); 

        transform.position = new Vector3(player.position.x, player.position.y, 0);
    }
}