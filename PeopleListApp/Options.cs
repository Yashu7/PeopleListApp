using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleListApp
{
    class Options
    {
        public void OptionMenu(SQLiteConnection p_dbConnection)
        {
            string selectedPeopleDB = "select * from People";
            SQLiteCommand viewWholeDB = new SQLiteCommand(selectedPeopleDB, p_dbConnection);
            SQLiteDataReader reader = viewWholeDB.ExecuteReader(); //Reader creation.

            Console.WriteLine("List of students: ");
            while (reader.Read()) //Reader implementation.
            Console.WriteLine("id: " + reader["id"] + "\tName: " + reader["name"] + "\tSurname: " + reader["surname"]);
        }
    }
}
