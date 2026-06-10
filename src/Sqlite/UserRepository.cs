using UnityEngine;

public class UserRepository : MonoBehaviour
{
    private static UserRepository _instance;
    public static UserRepository Instance
    {
        get
        {
            if (_instance == null)
                _instance = new UserRepository();
            return _instance;
        }
    }

    public bool Registrieren(string username, string password)
    {
        if (username == "" || password == "")
        {
            Debug.LogWarning("Username und Passwort dürfen nicht leer sein");
            return false;
        }
        if (username.Length < 3)
        {
            Debug.LogWarning("Username muss mindestens 3 Zeichen haben");
            return false;
        }
        if (password.Length < 4)
        {
            Debug.LogWarning("Passwort muss mindestens 4 Zeichen haben");
            return false;
        }
        try
        {
            using (var command = DatabaseConnection.Instance.GetConnection().CreateCommand())
            {
                command.CommandText = "INSERT OR IGNORE INTO Users (username, password) VALUES ('" + username + "', '" + password + "');";
                command.ExecuteNonQuery();
            }
            Debug.Log("Registrierung erfolgreich: " + username);
            return true;
        }
        catch
        {
            Debug.LogWarning("Registrierung fehlgeschlagen");
            return false;
        }
    }

    public int Login(string username, string password)
    {
        if (username == "" || password == "")
        {
            Debug.LogWarning("Username und Passwort dürfen nicht leer sein");
            return -1;
        }
        using (var command = DatabaseConnection.Instance.GetConnection().CreateCommand())
        {
            command.CommandText = "SELECT UserId FROM Users WHERE username = '" + username + "' AND password = '" + password + "';";
            var result = command.ExecuteScalar();
            if (result != null)
            {
                Debug.Log("Login erfolgreich: " + username);
                return System.Convert.ToInt32(result);
            }
        }
        Debug.LogWarning("Login fehlgeschlagen: falscher Username oder Passwort");
        return -1;
    }

    public void SpielstandSpeichern(int userId, string name, int experience, decimal money, int level)
    {
        if (userId <= 0)
        {
            Debug.LogWarning("Ungültige UserId");
            return;
        }
        if (experience < 0 || money < 0 || level < 1)
        {
            Debug.LogWarning("Ungültige Spielstandwerte");
            return;
        }
        using (var command = DatabaseConnection.Instance.GetConnection().CreateCommand())
        {
            command.CommandText = "INSERT OR REPLACE INTO Charakter (user_id, name, experience, money, level) VALUES (" + userId + ", '" + name + "', " + experience + ", " + money + ", " + level + ");";
            command.ExecuteNonQuery();
        }
        Debug.Log("Spielstand gespeichert");
    }

    public void SpielstandLaden(int userId)
    {
        if (userId <= 0)
        {
            Debug.LogWarning("Ungültige UserId");
            return;
        }
        using (var command = DatabaseConnection.Instance.GetConnection().CreateCommand())
        {
            command.CommandText = "SELECT * FROM Charakter WHERE user_id = " + userId + ";";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Debug.Log("Name: " + reader["name"] + "\tLevel: " + reader["level"] + "\tExperience: " + reader["experience"] + "\tMoney: " + reader["money"]);
                }
            }
        }
    }

    public void BenutzerLoeschen(int userId)
    {
        if (userId <= 0)
        {
            Debug.LogWarning("Ungültige UserId");
            return;
        }
        using (var command = DatabaseConnection.Instance.GetConnection().CreateCommand())
        {
            command.CommandText = "DELETE FROM Charakter WHERE user_id = " + userId + ";";
            command.ExecuteNonQuery();

            command.CommandText = "DELETE FROM Users WHERE UserId = " + userId + ";";
            command.ExecuteNonQuery();
        }
        Debug.Log("User gelöscht: " + userId);
    }
}