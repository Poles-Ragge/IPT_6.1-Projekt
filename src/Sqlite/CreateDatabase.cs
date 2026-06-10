using UnityEngine;
using Mono.Data.Sqlite;

public class DatabaseCreator : MonoBehaviour
{
    void Start()
    {
        CreateDB();
    }

    public void CreateDB()
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Users (UserId INTEGER PRIMARY KEY AUTOINCREMENT, username TEXT UNIQUE, password TEXT)";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS Effects (EFFId INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE, description TEXT)";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS Armour (ArmourId INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE, description TEXT, rarity TEXT, price DECIMAL(5, 2))";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS Charakter (ChaId INTEGER PRIMARY KEY AUTOINCREMENT, user_id INTEGER, name TEXT UNIQUE, experience INTEGER, money DECIMAL(6, 2), level INTEGER)";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS Item (ItemId INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE, description TEXT, rarity TEXT, price DECIMAL(5, 2))";
                command.ExecuteNonQuery();
            }
        }
        Debug.Log("Datenbank erstellt");
    }

    public void AddEffect(string effectName, string effectDescription)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT OR IGNORE INTO Effects (name, description) VALUES ('" + effectName + "', '" + effectDescription + "');";
                command.ExecuteNonQuery();
            }
        }
    }

    public void AddArmour(string armourName, string armourDescription, string armourRarity, decimal armourPrice)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT OR IGNORE INTO Armour (name, description, rarity, price) VALUES ('" + armourName + "', '" + armourDescription + "', '" + armourRarity + "', " + armourPrice + ");";
                command.ExecuteNonQuery();
            }
        }
    }

    public void AddCharakter(string charakterName, int userId, int experience, decimal money, int level)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT OR IGNORE INTO Charakter (user_id, name, experience, money, level) VALUES (" + userId + ", '" + charakterName + "', " + experience + ", " + money + ", " + level + ");";
                command.ExecuteNonQuery();
            }
        }
    }

    public void AddItem(string itemName, string itemDescription, string itemRarity, decimal itemPrice)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT OR IGNORE INTO Item (name, description, rarity, price) VALUES ('" + itemName + "', '" + itemDescription + "', '" + itemRarity + "', " + itemPrice + ");";
                command.ExecuteNonQuery();
            }
        }
    }

    public void DisplayEffects()
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Effects;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Name: " + reader["name"] + "\tDescription: " + reader["description"]);
                    }
                }
            }
        }
    }

    public void DisplayArmour()
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Armour;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Name: " + reader["name"] + "\tDescription: " + reader["description"] + "\tRarity: " + reader["rarity"] + "\tPrice: " + reader["price"]);
                    }
                }
            }
        }
    }

    public void DisplayCharakter()
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Charakter;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Name: " + reader["name"] + "\tExperience: " + reader["experience"] + "\tMoney: " + reader["money"] + "\tLevel: " + reader["level"]);
                    }
                }
            }
        }
    }

    public void DisplayItem()
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Item;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Name: " + reader["name"] + "\tDescription: " + reader["description"] + "\tRarity: " + reader["rarity"] + "\tPrice: " + reader["price"]);
                    }
                }
            }
        }
    }

    public void DisplayItemsByRarity(string rarity)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Item WHERE rarity = '" + rarity + "';";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Name: " + reader["name"] + "\tRarity: " + reader["rarity"] + "\tPrice: " + reader["price"]);
                    }
                }
            }
        }
    }

    public void DisplayArmoursByRarity(string rarity)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Armour WHERE rarity = '" + rarity + "';";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Name: " + reader["name"] + "\tRarity: " + reader["rarity"] + "\tPrice: " + reader["price"]);
                    }
                }
            }
        }
    }

    public void UpdateCharakter(int chaId, int experience, decimal money, int level)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Charakter SET experience = " + experience + ", money = " + money + ", level = " + level + " WHERE ChaId = " + chaId + ";";
                command.ExecuteNonQuery();
            }
        }
    }

    public void UpdateItem(int itemId, string description, string rarity, decimal price)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Item SET description = '" + description + "', rarity = '" + rarity + "', price = " + price + " WHERE ItemId = " + itemId + ";";
                command.ExecuteNonQuery();
            }
        }
    }

    public void UpdateArmour(int armourId, string description, string rarity, decimal price)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Armour SET description = '" + description + "', rarity = '" + rarity + "', price = " + price + " WHERE ArmourId = " + armourId + ";";
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteItem(int itemId)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Item WHERE ItemId = " + itemId + ";";
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteArmour(int armourId)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Armour WHERE ArmourId = " + armourId + ";";
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteEffect(int effId)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Effects WHERE EFFId = " + effId + ";";
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteCharakter(int chaId)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Charakter WHERE ChaId = " + chaId + ";";
                command.ExecuteNonQuery();
            }
        }
    }
}