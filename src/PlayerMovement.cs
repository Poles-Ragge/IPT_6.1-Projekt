using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float jump = 5;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;


    private Rigidbody2D rb;

    private Animator animator;

    private bool loop = true;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);



        }

        setAnimation();

    }

    private void FixedUpdate()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    }


    private void setAnimation()
    {
        if (loop == true)
        {
            animator.Play("Player_Animation");

        }
        else 
        {
            
        }
    }



}



