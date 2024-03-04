using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SQLite;
using System.IO;
using System;

public class sql : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string assetsPath = Application.dataPath;
        string path = Path.Combine(assetsPath, "Scripts/Adatbazisok/kartya.db");
        string connectionString = "Data Source="+path+";Version=3;";
        Debug.Log(path);
        using (var connection = new SQLiteConnection(connectionString))
        {
            try
            {
                // // Open the connection
                 connection.Open();
                
                // // Perform database operations here, like querying or inserting data

                 Debug.Log("Connection to SQLite database successful!");

                // // Don't forget to close the connection when done
                 connection.Close();
            }
            catch (Exception ex)
            {
                Debug.Log("Error: " + ex.Message);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
