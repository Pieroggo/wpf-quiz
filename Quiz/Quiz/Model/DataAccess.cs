using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace WPFQuiz.Model
{
    static class DataAccess
    {
        static SQLiteConnection conn = new SQLiteConnection(@"Data Source=..\quizzesbase.db;Version=3");


        private static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;

            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Quizzes";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                long id = (long)reader["id"];
                string quizname = (string)reader["quizname"];
                //kolejne atyrbuty
                Console.WriteLine($"{id} {quizname}");
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
        private static void InsertData(SQLiteConnection conn)
        {

        }

        public static void InsertData() {
            try
            {
                conn.Open();
                InsertData(conn);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
