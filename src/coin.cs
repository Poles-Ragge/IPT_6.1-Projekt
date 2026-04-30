using UnityEngine;

public class Coin : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            player.coins++;
            Destroy(gameObject);
        }
    }
}