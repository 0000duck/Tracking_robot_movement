using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DBScript : MonoBehaviour
{
    //store name of database
    private string dbName = "URI=file:robDB.db";

    void Start() {
        CreateDB();
    }
    
    public void CreateDB()
    {
        Debug.Log("Create DB");
        using (var connection = new SqliteConnection(dbName))
        {
            // opens connection
            connection.Open();
            // creates an object named command for controlling the database
            using (var command = connection.CreateCommand())
            {
                // create tabel with SQL syntax for tracking robot motion
                command.CommandText = "CREATE TABLE IF NOT EXISTS robot_movement (name VARCHAR(30)," +
                    "x FLOAT, z FLOAT)";
                // execute command on the database
                command.ExecuteNonQuery();
            }
            // close connection
            connection.Close();
        }
    }


    public void CreateRecord(string name, float x, float z)
    {
        Debug.Log("CreateRecord");
        // connect to database
        using (var connection = new SqliteConnection(dbName))
        {
            // open connection
            connection.Open();
            //create object command to control database
            using (var command = connection.CreateCommand())
            {
                // sql to create new robot movement coordinates
                command.CommandText = "INSERT INTO robot_movement (name, x, z) " +
                    "VALUES ('" + name + "', '" + x + "', '" + z + "');";
                //run the query
                command.ExecuteNonQuery();
            }
            //close connection
            connection.Close();
        }
    }


    public void ReadRecords()
    {
        // connect to database
        using (var connection = new SqliteConnection(dbName))
        {
            // open connection
            connection.Open();
            //create command to allow for database control
            using (var command = connection.CreateCommand())
            {
                //sql statement to read from table 
                command.CommandText = "SELECT * FROM robot_movement;";
                // iterate the returned records
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //output the value name, x, z for each record
                        Debug.Log("Name: " + reader["name"] + " X: " + reader["x"] + "Z: " + reader["z"]);
                    }
                    // close reader
                    reader.Close();
                }
            }
            //close connection 
            connection.Close();
        }
    }
}
