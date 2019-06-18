using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace PeopleListApp
{
    class Program
    {
        static void Main(string[] args)
        {


            
            SQLiteConnection p_dbConnection;
            p_dbConnection = new SQLiteConnection("Data Source =PersonDB.sqlite;Version=3;"); //Creating connection to existing DB.
            p_dbConnection.Open();

            string selectedPeopleDB = "select * from People";
            SQLiteCommand viewWholeDB = new SQLiteCommand(selectedPeopleDB, p_dbConnection);
            SQLiteDataReader reader = viewWholeDB.ExecuteReader(); //Reader creation.

            Console.WriteLine("List of students: ");
            while (reader.Read()) //Reader implementation.
                Console.WriteLine("id: " + reader["id"] + "\tName: " + reader["name"] + "\tSurname: " + reader["surname"]);
            
            string selectLastPerson = "SELECT *FROM People ORDER BY id DESC LIMIT 1";
            SQLiteCommand checkId = new SQLiteCommand(selectLastPerson, p_dbConnection);
            SQLiteDataReader Idreader = checkId.ExecuteReader();
            int newID = Convert.ToInt32(Idreader["id"]);/*Finds latest id and later adds 1 for next entry*/
            Console.WriteLine("Options:");
            Console.WriteLine("1.Create new entry into the database.");
            newID = newID + 1;
            string newName = Console.ReadLine();
            string newSurname = Console.ReadLine();
            string newPerson = String.Format("Insert into People (id,name,surname) values ('{0}','{1}','{2}')", newID, newName, newSurname);
            SQLiteCommand createCommand = new SQLiteCommand(newPerson, p_dbConnection);
            createCommand.ExecuteNonQuery();

            Console.WriteLine("2.Delete entry");
            
        }
    }
    class Database
    {
        public void CreateDatabase()
        {
            SQLiteConnection.CreateFile("PersonDB.sqlite"); //Used to create DB file.
            

        }
       
    }
}
    

