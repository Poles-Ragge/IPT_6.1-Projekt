using UnityEngine;

public class Medikit : MonoBehaviour, ICollectible
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            OnCollect(player);
            player.PlayMedikitSound();
            Destroy(gameObject);
        }
    }

    public void OnCollect(PlayerMovement player)
    {
        player.Heal(GetWert());
    }

    public int GetWert()
    {
        return 20;
    }
}