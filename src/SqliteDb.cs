using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class SqliteDb1 : MonoBehaviour
{
    private string dbName = "URI=file:mydatabase.db"; // Database file path

    void Start()
    {
        CreateDB();
        AddEffect("Effect1", "Description of Effect1");
       
        AddArmour("Armour1", "Description of Armour1", "rare", 10.2m);

        
        AddCharakter("Held1", 0, 100.0m, 1);

      
        AddItem("HealPotion", "Heals 50 HP", "common", 5.0m);

        DisplayEffects();
    }

    public void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
               
                command.CommandText = "CREATE TABLE IF NOT EXISTS Effects (EFFId INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE, description TEXT)";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS Armour (ArmourId INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE, description TEXT, rarity TEXT, price DECIMAL(5, 2))";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS Charakter (ChaId INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE, experience INTEGER, money DECIMAL(6, 2), level INTEGER)";
                command.ExecuteNonQuery();

               
                command.CommandText = "CREATE TABLE IF NOT EXISTS Item (ItemId INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE, description TEXT, rarity TEXT, price DECIMAL(5, 2))";
                command.ExecuteNonQuery();
            }
        }
    }

    public void AddEffect(string effectName, string effectDescription)
    {

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())

            {

                command.CommandText = "INSERT OR IGNORE INTO effects (name, description) VALUES ('" + effectName + "', '" + effectDescription + "');";

                command.ExecuteNonQuery();
            }




            connection.Close();


        }
    }


    public void AddArmour(string armourName, string armourDescription, string armourRarity, decimal armourPrice)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT OR IGNORE INTO Armour (name, description, rarity, price) VALUES ('" + armourName + "', '" + armourDescription + "', '" + armourRarity + "', " + armourPrice + ");";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void AddCharakter(string charakterName, int experience, decimal money, int level)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT OR IGNORE INTO Charakter (name, experience, money, level) VALUES ('" + charakterName + "', " + experience + ", " + money + ", " + level + ");";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }



    public void AddItem(string itemName,string itemDescription, string itemRarity, decimal itemPrice)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT OR IGNORE INTO Item(name, description, rarity, price) VALUES('" + itemName + "', '" + itemDescription + "', '" + itemRarity + "', " + itemPrice + "); ";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }


    

    public  void DisplayEffects()
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Effects;";
                    using (IDataReader reader = command.ExecuteReader())
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
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Armour;";
                using (IDataReader reader = command.ExecuteReader())
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
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Charakter;";
                using (IDataReader reader = command.ExecuteReader())
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
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Item;";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Name: " + reader["name"] + "\tDescription: " + reader["description"] + "\tRarity: " + reader["rarity"] + "\tPrice: " + reader["price"]);
                    }
                }
            }
        }
    }













    // Update is called once per frame
    void Update()
        {
        }
    }






