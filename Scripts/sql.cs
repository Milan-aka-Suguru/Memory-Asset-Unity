// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
// using MySql.Data.MySqlClient;
// using sqlite3;
using System;
using System.Data.SQLite;
using System.IO;
public class sql : MonoBehaviour
{
    void Start(){

        string assetsPath = Application.dataPath;

            // Construct the path to the "Scripts" folder relative to the "Assets" folder
        string path = Path.Combine(assetsPath, "Adatbazisok/kartya.db");
        // Connection string
        string connectionString = "Data Source="+path+";Version=3;";

        // Create a new SQLite connection
        using (var connection = new SQLiteConnection(connectionString))
        {
            try
            {
                // Open the connection
                connection.Open();
                
                // Perform database operations here, like querying or inserting data

                Debug.Log("Connection to SQLite database successful!");

                // Don't forget to close the connection when done
                connection.Close();
            }
            catch (Exception ex)
            {
                Debug.Log("Error: " + ex.Message);
            }
        }
    }
     
}
