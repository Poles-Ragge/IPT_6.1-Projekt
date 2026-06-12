using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    public int health = 100;

    public int coins;

    public float speed = 5;

    public float jump = 5;

    public float maxJumpTime = 0.3f;

    public Transform groundCheck;

    public float groundCheckRadius = 0.2f;


    public LayerMask groundLayer;

    public AudioClip jumpClip;

    public AudioClip damageClip;


    public AudioClip coinClip;
    public AudioClip medikitClip;

    private bool isGrounded;

    private bool isJumping;

    private float jumpTimer;
    private Rigidbody2D rb;

    private Animator animator;
    private bool loop = true;

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    public Image healthImage;

    public TextMeshProUGUI coinText;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
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
            isJumping = true;
            jumpTimer = 0f;
            PlaySound(jumpClip);
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimer < maxJumpTime)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        setAnimation();
        healthImage.fillAmount = health / 100f;
        if (coinText != null)
        {
            coinText.text = coins.ToString();

        }
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
            PlaySound(damageClip);
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
    private void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    public void PlayCoinSound()
    {
        PlaySound(coinClip);
    }
    public void PlayMedikitSound()
    {
        PlaySound(medikitClip);
    }
}