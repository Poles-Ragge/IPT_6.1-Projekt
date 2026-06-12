using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginUI : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject registerPanel;

    public TMP_InputField loginUsernameField;
    public TMP_InputField loginPasswordField;
    public TextMeshProUGUI loginMessageText;

    public TMP_InputField registerUsernameField;
    public TMP_InputField registerPasswordField;
    public TMP_InputField registerPasswordConfirmField;
    public TextMeshProUGUI registerMessageText;

    private UserRepository userRepo = new UserRepository();

    void Start()
    {
        loginPanel.SetActive(true);
        registerPanel.SetActive(false);
    }

    public void OnLoginClick()
    {
        string username = loginUsernameField.text;
        string password = loginPasswordField.text;

        if (username == "" || password == "")
        {
            loginMessageText.text = "Bitte alle Felder ausfüllen";
            return;
        }

        int userId = userRepo.Login(username, password);

        if (userId != -1)
        {
            PlayerPrefs.SetInt("UserId", userId);
            PlayerPrefs.SetString("Username", username);
            SceneManager.LoadScene("Level1");
        }
        else
        {
            loginMessageText.text = "Falscher Username oder Passwort";
        }
    }

    public void OnRegisterClick()
    {
        string username = registerUsernameField.text;
        string password = registerPasswordField.text;
        string passwordConfirm = registerPasswordConfirmField.text;

        if (username == "" || password == "" || passwordConfirm == "")
        {
            registerMessageText.text = "Bitte alle Felder ausfüllen";
            return;
        }
        if (username.Length < 3)
        {
            registerMessageText.text = "Username muss mindestens 3 Zeichen haben";
            return;
        }
        if (password.Length < 8)
        {
            registerMessageText.text = "Passwort muss mindestens 8 Zeichen haben";
            return;
        }
        if (password != passwordConfirm)
        {
            registerMessageText.text = "Passwörter stimmen nicht überein";
            return;
        }

        bool success = userRepo.Register(username, password);

        if (success)
        {
            registerMessageText.text = "Registrierung erfolgreich";
        }
        else
        {
            registerMessageText.text = "Username bereits vergeben";
        }
    }

    public void ShowRegister()
    {
        loginPanel.SetActive(false);
        registerPanel.SetActive(true);
    }

    public void ShowLogin()
    {
        registerPanel.SetActive(false);
        loginPanel.SetActive(true);
    }
}