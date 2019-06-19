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
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            


            SQLiteConnection p_dbConnection;
            p_dbConnection = new SQLiteConnection("Data Source =PersonDB.sqlite;Version=3;"); //Creating connection to existing DB.
            p_dbConnection.Open();
            Options Menus = new Options();

            int y = 0; //Variables for window scrolling.
            int x = 0;
            Menus.WholeList(p_dbConnection, y, x); //Calls OptionMenu method and passes connection to the DB.




            int MenuOption = 0; 
            do //Menu loop.
            {
                MenuOption = Menus.MenuOptions(MenuOption);

                switch (MenuOption)
                {
                    case 1:
                        ConsoleKeyInfo Exit;
                        do
                        {
                            string selectLastPerson = "SELECT *FROM People ORDER BY id DESC LIMIT 1";
                            SQLiteCommand checkId = new SQLiteCommand(selectLastPerson, p_dbConnection);
                            SQLiteDataReader Idreader = checkId.ExecuteReader();
                            int newID = Convert.ToInt32(Idreader["id"]);/*Finds latest id and later adds 1 for next entry*/
                            newID = newID + 1;

                            Console.WriteLine("Enter Name: ");
                            string newName = Console.ReadLine();
                            Console.WriteLine("Enter Surname: ");
                            string newSurname = Console.ReadLine();
                            string newPerson = String.Format("Insert into People (id,name,surname) values ('{0}','{1}','{2}')", newID, newName, newSurname);
                            SQLiteCommand createCommand = new SQLiteCommand(newPerson, p_dbConnection);
                            createCommand.ExecuteNonQuery();
                            Console.WriteLine("Press ESC if you want to quit or ENTER if you want to add another entry: ");
                            Exit = Console.ReadKey(false);
                        } while (Exit.Key != ConsoleKey.Escape);
                        MenuOption = 0; //Returns to menu.
                        break;
                    case 2:
                        Menus.Delete(p_dbConnection); //Function that deletes row in DB by id.
                        MenuOption = 0;
                        break;
                    case 3:
                        System.Environment.Exit(1); //Quits app.
                        break;
                    case 4:
                        Menus.WholeList(p_dbConnection, y, x); //Shows whole list again.
                        MenuOption = 0;
                        break;
                        
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("This option doesn't exist.");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        MenuOption = 0; //Returns to menu.
                        break;
                }
            }
            while (MenuOption == 0);

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
    

