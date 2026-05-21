using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;


    /// <summary>
    /// BASIC BULLET. BEI WAFFEN DIE JEWEILIGEN BULLETS BENUTZEN UM UNTERSCHIEDLICHEN SCHADEN ZU ERSTELLEN.!!!
    /// </summary>

    private void Start()
    {
        // Bullet wird automatisch vernichtet wenn laenger als X (in diesem fall 5, aendern bitte)
        Destroy(gameObject, 5f);
    }

    public void Fire(Vector2 direction)
    {
        // Setzt die Geschwindigkeit des Bullet basierend auf der Richtung (Aus altem Game)
        rb.linearVelocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vernichtet den Bullet, wenn es mit etwas kollidiert
        Destroy(gameObject);
    }
}
