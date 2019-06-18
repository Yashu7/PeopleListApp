﻿using System;
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
            Options Menus = new Options();

            Menus.WholeList(p_dbConnection); //Calls OptionMenu method and passes connection to the DB.
            int MenuOption = 0;
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
                            Exit = Console.ReadKey(false);
                        } while (Exit.Key != ConsoleKey.Escape);
                   
                    break;
                case 3:
                    System.Environment.Exit(1);
                    break;
                    default:
                        
                        break;
                }
                
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
    

