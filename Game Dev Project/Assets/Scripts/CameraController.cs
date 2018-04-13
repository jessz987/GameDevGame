using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Xmax;
    public float Xmin;

    public Vector3 offset;
    public Transform player;

    public float lerpSpeed;

    private void Start()
    {      
    }

    void Update()
    {
        Vector3 target = player.transform.position + offset;
        float camXExtent = Camera.main.orthographicSize * Camera.main.aspect;

        Debug.Log("camXExtent: " + camXExtent + ". target: " + target);

        if (target.x + camXExtent > Xmax + camXExtent)
        {
            Debug.Log("constraining max x");
            target.x = Xmax;
        }

        if (target.x - camXExtent < Xmin - camXExtent)
        {
            target.x = Xmin;
        }

        transform.position += (target - transform.position) * lerpSpeed;
    }
}