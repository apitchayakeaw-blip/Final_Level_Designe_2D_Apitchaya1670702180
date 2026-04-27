using UnityEngine;

public class Waepon : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);   
        }
    }
}
