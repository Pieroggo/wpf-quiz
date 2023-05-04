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
        static SQLiteConnection conn = new SQLiteConnection(@"Data Source=..\..\..\..\quizzesbase.db;Version=3");


        private static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;

            command = conn.CreateCommand();
            command.CommandText = "SELECT Quizzes.Id AS QuizID ,Quizzes.QuizName, Questions.Id AS QuestionID, Questions.Question, Questions.Answer1, Questions.Answer2, Questions.Answer3, Questions.Answer4, Questions.RightAnswer FROM Quizzes INNER JOIN Questions ON Quizzes.Id = Questions.QuizID";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                long quizid = (long)reader["quizid"];
                string quizname = (string)reader["quizname"];
                long questionid = (long)reader["questionid"];
                string question = (string)reader["question"];
                string answer1 = (string)reader["answer1"];
                string answer2 = (string)reader["answer2"];
                string answer3 = (string)reader["answer3"];
                string answer4 = (string)reader["answer4"];
                long rightanswer = (long)reader["rightanswer"];
                //kolejne atyrbuty

                Console.WriteLine($"{quizid} {quizname} {questionid} {question} {answer1} {answer2} {answer3} {answer4} {rightanswer}");
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
