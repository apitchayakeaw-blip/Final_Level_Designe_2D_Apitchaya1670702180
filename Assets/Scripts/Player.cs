using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float gravityMultiplier;

    public Transform cam;
    public Vector3 offset;
    

    public int maxHealth;
    public int health;

    public float Speed = 10;

    private InputAction jumpAction;
    public float JumpForce = 0.5f;
    bool isOnGround;

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
    protected virtual void Update()
    {
        Vector3 targetPosition = transform.position + offset;
        cam.position = Vector3.Lerp(cam.position, targetPosition, Speed * Time.deltaTime);
        
        var moveAction = InputSystem.actions.FindAction("Move");
        var hInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(hInput * Speed * Time.deltaTime * Vector3.right);

        if (jumpAction.triggered && isOnGround == true)
        {
            rb.AddForce(JumpForce * Vector2.up , ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log(this.gameObject.name + "On ground");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            gameOverScreen.Setup();
        }
    }
}
