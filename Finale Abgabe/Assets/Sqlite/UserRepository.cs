using UnityEngine;

public class UserRepository
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

    public bool Register(string username, string password)
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
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    Debug.LogWarning("Username bereits vergeben");
                    return false;
                }
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

    public void SaveGameState(int userId, string name, int experience, decimal money, int level, bool hasGewehr, float speed)
    {
        if (userId <= 0)
        {
            Debug.LogWarning("Ungültige UserId");
            return;
        }
        int gewehrInt = hasGewehr ? 1 : 0;
        using (var command = DatabaseConnection.Instance.GetConnection().CreateCommand())
        {
            command.CommandText = "INSERT OR REPLACE INTO Charakter (user_id, name, experience, money, level, has_gewehr, speed) VALUES (" + userId + ", '" + name + "', " + experience + ", " + money + ", " + level + ", " + gewehrInt + ", " + speed + ");";
            command.ExecuteNonQuery();
        }
        Debug.Log("Spielstand gespeichert");
    }

    public PlayerSaveData LoadGameState(int userId)
    {
        if (userId <= 0)
        {
            Debug.LogWarning("Ungültige UserId");
            return null;
        }
        using (var command = DatabaseConnection.Instance.GetConnection().CreateCommand())
        {
            command.CommandText = "SELECT * FROM Charakter WHERE user_id = " + userId + ";";
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    PlayerSaveData data = new PlayerSaveData();
                    data.name = reader["name"].ToString();
                    data.experience = System.Convert.ToInt32(reader["experience"]);
                    data.money = System.Convert.ToDecimal(reader["money"]);
                    data.level = System.Convert.ToInt32(reader["level"]);
                    data.hasGewehr = System.Convert.ToInt32(reader["has_gewehr"]) == 1;
                    data.speed = System.Convert.ToSingle(reader["speed"]);
                    return data;
                }
            }
        }
        return null;
    }

    public void DeleteUser(int userId)
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

public class PlayerSaveData
{
    public string name;
    public int experience;
    public decimal money;
    public int level;
    public bool hasGewehr;
    public float speed;
}