using UnityEngine;

public class Medikit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            player.Heal(20);
            player.PlayMedikitSound();
            Destroy(gameObject);
        }
    }
}