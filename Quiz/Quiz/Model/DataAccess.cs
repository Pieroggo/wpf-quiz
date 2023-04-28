﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    static class DataAccess
    {
        static SQLiteConnection conn = new SQLiteConnection(@"Data Source=bazaTest.db;Version=3");


        private static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;

            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Tabela";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                long id = (long)reader["id"];
                string imie = (string)reader["imie"];
                string nazwisko = (string)reader["nazwisko"];
                //kolejne atyrbuty
                Console.WriteLine($"{id} {imie} {nazwisko}");
            }


        }

        public static void ReadData()
        {
            try
            {
                conn.Open();
                ReadData(conn);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
