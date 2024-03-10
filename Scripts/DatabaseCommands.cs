using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SQLite;
using System.IO;
using System;

public class DatabaseCommands : MonoBehaviour
{
    void Start()
    {
        ConnectToDB();
    }
    private SQLiteConnection ConnectToDB(){
        string assetsPath = Application.dataPath;
        string path = Path.Combine(assetsPath, "Adatbazisok/kartya.db");
        string connectionString = "Data Source="+path+";Version=3;";
        return new SQLiteConnection(connectionString);
    }
    public byte[] GetImage(string sqlGet){
            SQLiteConnection connection = ConnectToDB();
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(sqlGet, connection);
            byte[] imageData = (byte[])command.ExecuteScalar();
            connection.Close();
            return imageData;
    }
    public void kepfeltolt()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
