using UnityEngine;
public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Shop geöffnet!");
            shopUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}