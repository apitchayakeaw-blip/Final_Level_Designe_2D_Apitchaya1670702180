using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    
    public static Vector3 lastChekpoint; // make both player have same checkpoint
    public static bool hasCheckPoint;
    public GameObject Save;
    public GameObject UnSave;

    void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {         
            lastChekpoint = transform.position;
            hasCheckPoint = true;

            Save.SetActive(true);
            UnSave.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
