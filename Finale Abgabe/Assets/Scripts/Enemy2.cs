using UnityEngine;
using System.Collections;
public class Enemy2 : MonoBehaviour
{
    public int speed = 20;
    public float delayDuration = 0.5f;
    public Transform posA, posB;
    public float health = 50f;
    private Vector3 targetPos;
    private SpriteRenderer spriteRenderer;
    private bool isWaiting;
    void Start()
    {
        targetPos = posB.position;
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
        if (targetPos == (Vector3)posB.position)
        {
            targetPos = posA.position;
        }
        else
        {
            targetPos = posB.position;
        }
        yield return new WaitForSeconds(delayDuration);
        isWaiting = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}