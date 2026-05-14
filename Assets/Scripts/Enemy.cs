using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int damage;
    public int health;

    Animator animator;

    public SpriteRenderer spriteRenderer;   


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player p = collision.gameObject.GetComponent<Player>();

            if (p != null)
            {
                p.TakeDamage(damage);
            }

            Player_Monster pm = collision.gameObject.GetComponent<Player_Monster>();

            if (pm != null)
            {
                pm.TakeDamage(damage);
                Debug.Log(damage);
            }

        }
    }

    public void TakeDamage(int damage)
    {

        StartCoroutine(FlashRed());
        health -= damage;
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = Color.white;
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}