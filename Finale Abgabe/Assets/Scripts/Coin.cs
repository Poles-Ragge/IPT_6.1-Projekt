using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class Coin : MonoBehaviour, ICollectible
{
    public AudioClip coinClip;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            OnCollect(player);
            player.PlayCoinSound();
            Destroy(gameObject);
        }
    }
    public void OnCollect(PlayerMovement player)
    {
        player.coins += GetWert();
    }
    public int GetWert()
    {
        return 1;
    }
}