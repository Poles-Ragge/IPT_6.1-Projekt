using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public PlayerMovement player;
    public TextMeshProUGUI messageText;

    public int gewehrPrice = 5;
    public int speedBoostPrice = 30;
    public float speedBoostAmount = 2f;

    private Waffe gewehr = new Waffe("Gewehr", "common", 5, 15f);

    public void BuyGewehr()
    {
        if (player.hasGewehr)
        {
            messageText.text = "Du hast schon ein Gewehr";
            return;
        }

        if (player.coins >= gewehrPrice)
        {
            player.coins -= gewehrPrice;
            player.hasGewehr = true;
            player.SpeichereSpielstand();
            messageText.text = gewehr.Beschreibung() + " gekauft!";
        }
        else
        {
            messageText.text = "Nicht genug Coins";
        }
    }

    public void BuySpeedBoost()
    {
        if (player.coins >= speedBoostPrice)
        {
            player.coins -= speedBoostPrice;
            player.speed += speedBoostAmount;
            player.SpeichereSpielstand();
            messageText.text = "Speed Boost gekauft!";
        }
        else
        {
            messageText.text = "Nicht genug Coins";
        }
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}