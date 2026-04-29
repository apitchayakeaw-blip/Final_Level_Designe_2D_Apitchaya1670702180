using UnityEngine;

public class Switch : MonoBehaviour
{
    
    public MovingPlatforms platforms;
    public bool playerInRange = false;

    //private Renderer rend;
    //private bool IsRed = false;

    public GameObject SwitchOn;
    public GameObject SwitchOff;

    private bool isOn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rend = GetComponent<Renderer>();

        if (SwitchOn != null) SwitchOn.SetActive(true);
        if (SwitchOff != null) SwitchOff.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))      
        {

            isOn = !isOn;
                
            SwitchOn.SetActive(isOn);           
            SwitchOff.SetActive(!isOn);

            if (platforms != null)
            {
                platforms.TogglePlatform();
            }

                 
            //IsRed = !IsRed;

            //rend.material.color = IsRed ? Color.red : Color.white;
           

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
