using Spring.Data.Common;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repozytorium
{
    public class BazaDanych
    {
        public BazaDanych()
        {
            IDbProvider dbProvider = DbProviderFactory.GetDbProvider("System.Data.SQLite");

            SQLiteConnection.CreateFile("bazadanych.sql");
            
            using (SQLiteConnection con = new SQLiteConnection("Data Source=bazadanych.sql;Version=3;"))
            {
                con.Open();

                using (SQLiteCommand com = new SQLiteCommand(con))
                {
                    com.Connection = con;
                    com.CommandText = "CREATE TABLE highscores (name VARCHAR(20), score INT)";
                    var rezult = com.ExecuteNonQuery();

                }
            }
            
           

        }
         


    }
}
