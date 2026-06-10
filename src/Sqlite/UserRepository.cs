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

    public bool Registrieren(string username, string password)
    {
        try
        {
            using (var command = DatabaseConnection.Instance.GetConnection().CreateCommand())
            {
                command.CommandText = "INSERT OR IGNORE INTO Users (username, password) VALUES ('" + username + "', '" + password + "');";
                command.ExecuteNonQuery();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public int Login(string username, string password)
    {
        using (var command = DatabaseConnection.Instance.GetConnection().CreateCommand())
        {
            command.CommandText = "SELECT UserId FROM Users WHERE username = '" + username + "' AND password = '" + password + "';";
            var result = command.ExecuteScalar();
            if (result != null)
                return System.Convert.ToInt32(result);
        }
        return -1;
    }

    public void SpielstandSpeichern(int userId, string name, int experience, decimal money, int level)
    {
        using (var command = DatabaseConnection.Instance.GetConnection().CreateCommand())
        {
            command.CommandText = "INSERT OR REPLACE INTO Charakter (user_id, name, experience, money, level) VALUES (" + userId + ", '" + name + "', " + experience + ", " + money + ", " + level + ");";
            command.ExecuteNonQuery();
        }
    }

    public void SpielstandLaden(int userId)
    {
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
        using (var command = DatabaseConnection.Instance.GetConnection().CreateCommand())
        {
            command.CommandText = "DELETE FROM Charakter WHERE user_id = " + userId + ";";
            command.ExecuteNonQuery();

            command.CommandText = "DELETE FROM Users WHERE UserId = " + userId + ";";
            command.ExecuteNonQuery();
        }
    }
}