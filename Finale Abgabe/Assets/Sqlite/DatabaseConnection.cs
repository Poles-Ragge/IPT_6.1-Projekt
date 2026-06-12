using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DatabaseConnection : MonoBehaviour
{
    private static DatabaseConnection _instance;
    public static DatabaseConnection Instance { get { return _instance; } }

    private SqliteConnection _connection;
    public string dbName;

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        dbName = "URI=file:" + Application.persistentDataPath + "/mydatabase.db";
    }

    public SqliteConnection GetConnection()
    {
        if (_connection == null || _connection.State == ConnectionState.Closed)
        {
            _connection = new SqliteConnection(dbName);
            _connection.Open();
        }
        return _connection;
    }

    void OnDestroy()
    {
        if (_connection != null)
            _connection.Close();
    }
}