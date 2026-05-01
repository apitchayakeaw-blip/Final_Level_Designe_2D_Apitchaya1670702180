using UnityEngine;

public class Mashroom : MonoBehaviour
{
    public float Forced = 20;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            


            Player player = collision.gameObject.GetComponent<Player>();
            player.rb.AddForce(Vector2.up * Forced, ForceMode2D.Impulse);
        }
    }

}
