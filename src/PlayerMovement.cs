using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public int health = 100;

    public float speed = 5;
    public float jump = 5;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;


    private Rigidbody2D rb;

    private Animator animator;

    private bool loop = true;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
           
                StartCoroutine(blinkRed());
            health -= 10;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
            Debug.Log("Player Health: " + health);
          

            if (health <= 0)
            {

                Die();

              
                
            }
        }
    }

    private IEnumerator blinkRed()
    { 
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }


    private void Die()
{
    UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    Debug.Log("Player is dead!");
}

}





