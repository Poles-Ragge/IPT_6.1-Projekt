using UnityEngine;
using System.Collections;


public class Enemy2 : MonoBehaviour
{
    public int speed = 2;
    public float delayDuration = 0.5f;
    public Transform posA, posB;
    public Vector3 targetPos;
    private Animator animator;
    private bool isWaiting;
    private SpriteRenderer spriteRenderer;
        

    void Start()
    {
        targetPos = posB.position;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isWaiting)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        spriteRenderer.flipX = (transform.position.x < targetPos.x);
        if (Vector2.Distance(transform.position, targetPos) < 0.02f)
        {
            StartCoroutine(Delay());
        }

      
    }

    private IEnumerator Delay()
    {
        isWaiting = true;
        if (Vector2.Distance(transform.position, posB.position) < 0.02f)
        {
            targetPos = posA.position;
        }
        if (Vector2.Distance(transform.position, posA.position) < 0.02f)
        {
            targetPos = posB.position;
        }
        yield return new WaitForSeconds(delayDuration);
        isWaiting = false;

    }
}


