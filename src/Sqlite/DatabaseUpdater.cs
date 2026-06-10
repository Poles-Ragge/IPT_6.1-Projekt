using UnityEngine;

public class DatabaseUpdater : MonoBehaviour
{
    private int aktuelleVersion = 1;

    void Start()
    {
        RunUpdate();
    }

    public void RunUpdate()
    {
        int dbVersion = GetVersion();

        if (dbVersion < aktuelleVersion)
        {
            ApplyUpdate(dbVersion);
        }
    }

    private int GetVersion()
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT version FROM DbVersion LIMIT 1;";
                var result = command.ExecuteScalar();

                if (result != null)
                    return System.Convert.ToInt32(result);

                return 0;
            }
        }
    }

    private void ApplyUpdate(int vonVersion)
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE DbVersion SET version = " + aktuelleVersion + ";";
                command.ExecuteNonQuery();
            }
        }
    }
}