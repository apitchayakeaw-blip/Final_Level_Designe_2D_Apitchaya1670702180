using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float gravityMultiplier;

    bool facingRight = true;

    public Animator animator;

    // Camera Fllow
    public Transform cam;
    public Vector3 offset;

    //Respawn Player
    public Vector3 respawnPoint;

    public int maxHealth;
    public int health;

    public float Speed = 10;

    private InputAction jumpAction;
    public float JumpForce = 0.5f;
    bool isOnGround;

    public bool DebugColider;

    public GameOverScreen gameOverScreen;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpAction = InputSystem.actions.FindAction("Jump");


        Physics2D.gravity = new Vector2(0, -9.81f);

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
       rb.gravityScale = gravityMultiplier;
        
       maxHealth = 1;
       health = maxHealth;

       
    }

    // Update is called once per frame

    protected virtual void FixedUpdate()
    {
        Vector3 targetPosition = transform.position + offset;
        cam.position = Vector3.Lerp(cam.position, targetPosition, Speed * Time.deltaTime);

        //var moveAction = InputSystem.actions.FindAction("Move");
        //var input = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(input.x * Speed, rb.linearVelocityY);
        //transform.Translate(new Vector3(input.x, 0, 0) * Speed * Time.deltaTime);

        if (input.x > 0 && !facingRight)
        {
            Flip();
        }

        else if (input.x < 0 && facingRight)
        {
            Flip();
        }

        if (input.x != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (rb.linearVelocity.y > 0.1f)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
        }
        else if (rb.linearVelocity.y < -0.1f)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }


    }

    Vector2 input = Vector2.zero;
    protected virtual void Update()
    {

        var moveAction = InputSystem.actions.FindAction("Move");
        input = moveAction.ReadValue<Vector2>();
        
        //Vector3 targetPosition = transform.position + offset;
        //cam.position = Vector3.Lerp(cam.position, targetPosition, Speed * Time.deltaTime);
    
        /*var moveAction = InputSystem.actions.FindAction("Move");
        var  input = moveAction.ReadValue<Vector2>();
        transform.Translate(new Vector3(input.x, 0, 0) * Speed * Time.deltaTime);

        if (input.x > 0 && !facingRight)
        {
          Flip();
        }
           
        else if (input.x < 0 && facingRight)
        {
            Flip();
        }

        if(input.x != 0)
        {
            animator.SetBool("isWalking" , true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }*/
           

        if (jumpAction.triggered && isOnGround == true)
        {
            rb.AddForce(JumpForce * Vector2.up , ForceMode2D.Impulse);
            isOnGround = false;
        }


    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       if ( DebugColider)
        {
            Debug.Log(collision.gameObject.name);
        }
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            
        }

        if (collision.gameObject.tag == "Death")
        {
            RespawnAllPlayer();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {       
            //gameOverScreen.Setup();
            RespawnAllPlayer(); // death
        }
    }
   

    private void RespawnAllPlayer() // Make All player go same checkpoint
    {
        Player[] players = FindObjectsByType<Player>(FindObjectsSortMode.None);
        foreach (Player p in players)
        {
            p.health = p.maxHealth;
            p.RespawnNow();
        }
    }

    public void RespawnNow()
    {
        if (CheckPoint.hasCheckPoint) // hit checkpoint
        {
            transform.position = CheckPoint.lastChekpoint;
        }
        else // didn't hit any checkpoit yet
        {
            transform.position = respawnPoint;
        }
    }
}
