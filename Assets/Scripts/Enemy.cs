using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player p = collision.gameObject.GetComponent<Player>();

            if(p != null)

            {
                p.TakeDamage(damage);
            }
            
           Player_Monster pm = collision.gameObject.GetComponent<Player_Monster>();

            if(pm != null)
            {
                pm.TakeDamage(damage);
            }
            
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
