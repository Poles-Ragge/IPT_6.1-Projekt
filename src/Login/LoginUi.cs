using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginUI : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public TextMeshProUGUI messageText;

    private UserRepository userRepo = new UserRepository();

    public void OnLoginClick()
    {
        string username = usernameField.text;
        string password = passwordField.text;

        int userId = userRepo.Login(username, password);

        if (userId != -1)
        {
            PlayerPrefs.SetInt("UserId", userId);
            PlayerPrefs.SetString("Username", username);
            SceneManager.LoadScene("Level1");
        }
        else
        {
            messageText.text = "Falscher Username oder Passwort";
        }
    }

    public void OnRegisterClick()
    {
        string username = usernameField.text;
        string password = passwordField.text;

        bool success = userRepo.Registrieren(username, password);

        if (success)
        {
            messageText.text = "Registrierung erfolgreich";
        }
        else
        {
            messageText.text = "Registrierung fehlgeschlagen";
        }
    }
}