using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Coin : MonoBehaviour
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
            player.coins++;
            player.PlayCoinSound();
            Destroy(gameObject);
        }
    }

    private void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}