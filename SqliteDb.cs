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
        DisplayEffects();
    }

    public void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                string sqlQuery = "CREATE TABLE IF NOT EXISTS Effects (EFFId INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE, description TEXT)";
                string sqlQuery2 = "CREATE TABLE IF NOT EXISTS Armour (ArmourId INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE, description TEXT, rarity TEXT, price DECIMAL(5, 2))";
                string sqlQuery3 = "CREATE TABLE IF NOT EXISTS Charakter (ChaId INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE,experience INTEGER , money DECIMAL(6,2), level INTEGER)";
                string sqlQuery4 = "CREATE TABLE IF NOT EXISTS Item ( ItemId INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE, rarity TEXT, price DECIMAL(5,2)";
                command.CommandText = sqlQuery;
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


    public void AddArmour(string armourName, string armourDescription, string rarity, decimal price)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT OR IGNORE INTO Armour (name, description, rarity, price) VALUES ('" + armourName + "', '" + armourDescription + "', '" + rarity + "', " + price + ");";
                command.ExecuteNonQuery();
            }
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

    

  

   

   

    // Update is called once per frame
    void Update()
        {
        }
    }






