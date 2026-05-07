using UnityEngine;

public class Win : MonoBehaviour
{

    public GameObject winUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("You win!");
            winUI.SetActive(true);

        }
    }
}
