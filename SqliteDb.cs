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
                string sqlQuery = "CREATE TABLE IF NOT EXISTS Effects (Id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE, description TEXT)";
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






