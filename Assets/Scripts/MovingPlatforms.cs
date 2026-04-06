using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    public Transform PointA;
    public Transform PointB;

    public float speed = 3f;
    private bool isMoving = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform target;

        if (isMoving)
        {
            target = PointA;
        }
        else
        {
            target = PointB;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void TogglePlatform()
    {
        isMoving = !isMoving;
    }
}
