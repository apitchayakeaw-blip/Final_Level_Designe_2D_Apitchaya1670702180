using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float gravityMultiplier = 20f;

    

    public float Speed = 10;

    private InputAction jumpAction;
    public float JumpForce = 0.5f;
    bool isOnGround;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpAction = InputSystem.actions.FindAction("Jump");

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Physics2D.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
              
       
        
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
}
