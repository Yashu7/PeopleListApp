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
        public void WholeList(SQLiteConnection p_dbConnection, int y, int x)
        {
            string selectedPeopleDB = "select * from People";
            SQLiteCommand viewWholeDB = new SQLiteCommand(selectedPeopleDB, p_dbConnection);
            SQLiteDataReader reader = viewWholeDB.ExecuteReader(); //Reader creation.

            Console.WriteLine("List of students: ");
            while (reader.Read()) //Reader implementation.
                Console.WriteLine("id: " + reader["id"] + "\tName: " + reader["name"] + "\tSurname: " + reader["surname"]);
            ConsoleKeyInfo Down;
            Console.WriteLine("You can navigate through list by using Up and Down button, if you wish to quit list press ESC.");
            do
            {
                Down = Console.ReadKey();
                if (Down.Key == ConsoleKey.DownArrow)
                {
                    y++;
                    Console.SetWindowPosition(x, y);
                }
                if (Down.Key == ConsoleKey.UpArrow)
                {
                    
                    
                    y--;
                    if (y < 0) y++;
                        
                    
                    Console.SetWindowPosition(x, y);
                }
            } while ((Down.Key != ConsoleKey.Escape));
        }
        public int MenuOptions(int MenuOption)
        {
            
            do
            {
                Console.WriteLine("Options: ");
                Console.WriteLine("1.Create new entry into the database.");
                Console.WriteLine("2.Delete entry");
                Console.WriteLine("3.Exit");
                Console.WriteLine("4.List");
                Console.WriteLine("Enter correct option number: ");
                try
                {
                    MenuOption = Convert.ToInt32(Console.ReadLine());
                   
                }
                catch (FormatException) //Try/Catch if value isn't integer.
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Option doesn't exist, please try again. (Options 1-3)");
                    MenuOption = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
            } while (MenuOption == 0);
            return (MenuOption);
            
        }
        public void Delete(SQLiteConnection p_dbConnection, int y, int x) //Function that deletes row  by id.
        {
            Console.WriteLine("First look at the list again: ");
            WholeList(p_dbConnection, y, x);
            Console.WriteLine("Insert Id number of person from the list you wish to delete.");
            string IdToDelete = Console.ReadLine();
            string deleteRow = String.Format("DELETE FROM People WHERE id = '{0}'", IdToDelete);
            SQLiteCommand deleteCommand = new SQLiteCommand(deleteRow, p_dbConnection);
            deleteCommand.ExecuteNonQuery();
        }
    }
}
