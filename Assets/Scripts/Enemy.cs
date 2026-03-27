using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private int movespeed;

    private Transform pointerTransform;
    private Vector2 targetPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointerTransform = GetComponent<Transform>();
        targetPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        pointerTransform.position = Vector2.MoveTowards(pointerTransform.position, targetPosition, movespeed * Time.deltaTime);

        if (Vector2.Distance(pointerTransform.position, pointA.position) < 0.1f)
        {
            targetPosition = pointB.position;

        }
        else if (Vector2.Distance(pointerTransform.position, pointB.position) < 0.1f)
        {
            targetPosition = pointA.position;

        }
    }
}
