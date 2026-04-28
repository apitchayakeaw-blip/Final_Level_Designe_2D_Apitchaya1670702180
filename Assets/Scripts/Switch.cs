using UnityEngine;

public class Switch : MonoBehaviour
{
    
    public MovingPlatforms platforms;
    public bool playerInRange = false;

    private Renderer rend;
    private bool IsRed = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))      
        {
            platforms.TogglePlatform();          
            IsRed = !IsRed;

            rend.material.color = IsRed ? Color.red : Color.white;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
