using UnityEngine;

public class DatabaseUpdater : MonoBehaviour
{
    private int aktuelleVersion = 2;

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
        else
        {
            Debug.Log("Datenbank ist aktuell");
        }
    }

    private int GetVersion()
    {
        using (var connection = DatabaseConnection.Instance.GetConnection())
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS DbVersion (version INTEGER)";
                command.ExecuteNonQuery();

                command.CommandText = "SELECT version FROM DbVersion LIMIT 1;";
                var result = command.ExecuteScalar();
                if (result != null)
                    return System.Convert.ToInt32(result);

                command.CommandText = "INSERT INTO DbVersion (version) VALUES (0);";
                command.ExecuteNonQuery();
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
                if (vonVersion < 1)
                {
                    Debug.Log("Update auf Version 1 wird angewendet");
                }

                if (vonVersion < 2)
                {
                    Debug.Log("Update auf Version 2 wird angewendet");
                    command.CommandText = "ALTER TABLE Charakter ADD COLUMN has_gewehr INTEGER DEFAULT 0";
                    command.ExecuteNonQuery();

                    command.CommandText = "ALTER TABLE Charakter ADD COLUMN speed DECIMAL(4,2) DEFAULT 5";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "UPDATE DbVersion SET version = " + aktuelleVersion + ";";
                command.ExecuteNonQuery();
            }
        }
    }
}