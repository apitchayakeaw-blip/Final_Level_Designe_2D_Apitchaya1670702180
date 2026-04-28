using UnityEngine;

public class EnemyA : Enemy
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private int movespeed;

    private Transform enemyTransform;
    private Vector2 targetPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyTransform = GetComponent<Transform>();
        targetPosition = pointB.position;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, targetPosition, movespeed * Time.deltaTime);

        if (Vector2.Distance(enemyTransform.position, pointA.position) < 0.1f)
        {
            targetPosition = pointB.position;
            Flip();

        }
        else if (Vector2.Distance(enemyTransform.position, pointB.position) < 0.1f)
        {
            targetPosition = pointA.position;
            Flip();

        }
    }

   
    public void Flip()
    {
      
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

   
}
