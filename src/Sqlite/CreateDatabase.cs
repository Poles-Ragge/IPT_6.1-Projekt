using UnityEngine;
using Mono.Data.Sqlite;

public class CreateDatabase : MonoBehaviour
{
    void Awake()
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
        if (effectName == "")
        {
            Debug.LogWarning("Effect Name darf nicht leer sein");
            return;
        }
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
        if (armourName == "")
        {
            Debug.LogWarning("Armour Name darf nicht leer sein");
            return;
        }
        if (armourPrice < 0)
        {
            Debug.LogWarning("Preis darf nicht negativ sein");
            return;
        }
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
        if (charakterName == "")
        {
            Debug.LogWarning("Charakter Name darf nicht leer sein");
            return;
        }
        if (level < 1 || experience < 0 || money < 0)
        {
            Debug.LogWarning("Ungültige Charakter Werte");
            return;
        }
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
        if (itemName == "")
        {
            Debug.LogWarning("Item Name darf nicht leer sein");
            return;
        }
        if (itemPrice < 0)
        {
            Debug.LogWarning("Preis darf nicht negativ sein");
            return;
        }
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
        if (rarity == "")
        {
            Debug.LogWarning("Rarity darf nicht leer sein");
            return;
        }
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
        if (rarity == "")
        {
            Debug.LogWarning("Rarity darf nicht leer sein");
            return;
        }
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
        if (chaId <= 0)
        {
            Debug.LogWarning("Ungültige ChaId");
            return;
        }
        if (experience < 0 || money < 0 || level < 1)
        {
            Debug.LogWarning("Ungültige Charakter Werte");
            return;
        }
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
        if (itemId <= 0)
        {
            Debug.LogWarning("Ungültige ItemId");
            return;
        }
        if (price < 0)
        {
            Debug.LogWarning("Preis darf nicht negativ sein");
            return;
        }
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
        if (armourId <= 0)
        {
            Debug.LogWarning("Ungültige ArmourId");
            return;
        }
        if (price < 0)
        {
            Debug.LogWarning("Preis darf nicht negativ sein");
            return;
        }
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
        if (itemId <= 0)
        {
            Debug.LogWarning("Ungültige ItemId");
            return;
        }
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
        if (armourId <= 0)
        {
            Debug.LogWarning("Ungültige ArmourId");
            return;
        }
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
        if (effId <= 0)
        {
            Debug.LogWarning("Ungültige EFFId");
            return;
        }
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
        if (chaId <= 0)
        {
            Debug.LogWarning("Ungültige ChaId");
            return;
        }
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Charakter WHERE ChaId = " + chaId + ";";
                command.ExecuteNonQuery();
            }
        }
    }

    public int GetItemCount()
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM Item;";
                return System.Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }

    public int GetItemId(string name)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT ItemId FROM Item WHERE name = '" + name + "';";
                var result = command.ExecuteScalar();
                if (result != null)
                    return System.Convert.ToInt32(result);
            }
        }
        return -1;
    }

    public string GetItemRarity(int itemId)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT rarity FROM Item WHERE ItemId = " + itemId + ";";
                var result = command.ExecuteScalar();
                return result != null ? result.ToString() : "";
            }
        }
    }
}