using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public int health;

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
                Debug.Log(damage);
            }
            
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
           Destroy(gameObject);
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
