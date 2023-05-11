using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator.Model
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
                bool newQuiz = true;
               foreach(QuizInstance quiz in MainModel.Quizy){
                    if (quiz.ID == quizid) {
                        newQuiz= false;
                    }
                }
                if (newQuiz) {
                    MainModel.MakeNewQuiz(quizid, quizname);
                }
                MainModel.InsertQuestion(new Question(questionid, question, answer1, answer2, answer3, answer4, rightanswer),quizid);
                Console.WriteLine($"{quizid} {quizname} {questionid} {question} {answer1} {answer2} {answer3} {answer4} {rightanswer}");
                
            }
            Console.WriteLine(MainModel.ReturnContentString());


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

        private static void ReadQuizes(SQLiteConnection conn)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;

            command = conn.CreateCommand();
            command.CommandText = "SELECT Quizzes.Id AS QuizID ,Quizzes.QuizName FROM Quizzes";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                long quizid = (long)reader["quizid"];
                string quizname = (string)reader["quizname"];
                //kolejne atyrbuty
                bool newQuiz = true;

                foreach (QuizInstance quiz in MainModel.Quizy)
                {
                    if (quiz.ID == quizid)
                    {
                        newQuiz = false;
                    }
                }
                if (newQuiz)
                {
                    MainModel.MakeNewQuiz(quizid, quizname);
                }

                Console.WriteLine($"{quizid} {quizname}");

            }
            Console.WriteLine(MainModel.ReturnContentString());


        }

        public static void ReadQuizes()
        {
            try
            {
                conn.Open();
                ReadQuizes(conn);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ReadQuestionsForQuiz(SQLiteConnection conn, QuizInstance quiz)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;

            command = conn.CreateCommand();
            command.CommandText = $"SELECT DISTINCT Questions.Id AS QuestionID, Questions.Question, Questions.Answer1, Questions.Answer2, Questions.Answer3, Questions.Answer4, Questions.RightAnswer FROM Quizzes INNER JOIN Questions ON {quiz.ID} = Questions.QuizID";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                long questionid = (long)reader["questionid"];
                string question = (string)reader["question"];
                string answer1 = (string)reader["answer1"];
                string answer2 = (string)reader["answer2"];
                string answer3 = (string)reader["answer3"];
                string answer4 = (string)reader["answer4"];
                long rightanswer = (long)reader["rightanswer"];
                //kolejne atyrbuty

                MainModel.InsertQuestion(new Question(questionid, question, answer1, answer2, answer3, answer4, rightanswer), quiz.ID);
                Console.WriteLine($"{questionid} {question} {answer1} {answer2} {answer3} {answer4} {rightanswer}");

            }
            Console.WriteLine(MainModel.ReturnContentString());


        }

        public static void ReadQuestionsForQuiz(QuizInstance quiz)
        {
            try
            {
                conn.Open();
                ReadQuestionsForQuiz(conn, quiz);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void InsertNewQuiz(SQLiteConnection conn, long quizid, string quizname)
        {
            SQLiteCommand command;

            command = conn.CreateCommand();
            command.CommandText = $"INSERT INTO Quizzes VALUES ({quizid}, \"{quizname}\")";
            command.ExecuteNonQuery();
        }

        public static void InsertNewQuiz(long quizid, string quizname)
        {
            try
            {
                conn.Open();
                InsertNewQuiz(conn, quizid, quizname);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void InsertNewQuestion(SQLiteConnection conn, string qText, string a1, string a2, string a3, string a4, long right, QuizInstance quiz)
        {
            SQLiteCommand command;

            command = conn.CreateCommand();
            command.CommandText = $"INSERT INTO Questions (Question, Answer1, Answer2, Answer3, Answer4, RightAnswer, QuizId) VALUES (\"{qText}\", \"{a1}\", \"{a2}\", \"{a3}\", \"{a4}\", {right}, {quiz.ID})";
            command.ExecuteNonQuery();
        }

        public static void InsertNewQuestion(string qText, string a1, string a2, string a3, string a4, long right, QuizInstance quiz)
        {
            try
            {
                conn.Open();
                InsertNewQuestion(conn, qText, a1, a2, a3, a4, right, quiz);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void DropQuiz(SQLiteConnection conn, QuizInstance quiz)
        {
            SQLiteCommand command;
            SQLiteCommand command2;

            command = conn.CreateCommand();
            command2 = conn.CreateCommand();

            command.CommandText = $"DELETE FROM Questions WHERE QuizId = {quiz.ID}";
            command2.CommandText = $"DELETE FROM Quizzes WHERE Id = {quiz.ID}";

            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
        }

        public static void DropQuiz(QuizInstance quiz)
        {
            try
            {
                conn.Open();
                DropQuiz(conn, quiz);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void DropQuestion(SQLiteConnection conn, Question question, QuizInstance quiz)
        {
            SQLiteCommand command;

            command = conn.CreateCommand();

            command.CommandText = $"DELETE FROM Questions WHERE Question = \"{question.QuestionText}\" AND QuizId = {quiz.ID}";

            command.ExecuteNonQuery();
        }

        public static void DropQuestion(Question question, QuizInstance quiz)
        {
            try
            {
                conn.Open();
                DropQuestion(conn, question, quiz);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void SaveQuestion(SQLiteConnection conn, Question question, QuizInstance quiz, string oldText)
        {
            SQLiteCommand command;

            command = conn.CreateCommand();

            command.CommandText = $"UPDATE Questions SET Question = \"{question.QuestionText}\", Answer1 = \"{question.Answer1}\", Answer2 = \"{question.Answer2}\", Answer3 = \"{question.Answer3}\", Answer4 = \"{question.Answer4}\", RightAnswer = {question.RightAnswer} WHERE Question = \"{oldText}\" AND QuizId = {quiz.ID}";

            command.ExecuteNonQuery();
        }

        public static void SaveQuestion(Question question, QuizInstance quiz, string oldText)
        {
            try
            {
                conn.Open();
                SaveQuestion(conn, question, quiz, oldText);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void SaveQuiz(SQLiteConnection conn, QuizInstance quiz)
        {
            SQLiteCommand command;

            command = conn.CreateCommand();

            command.CommandText = $"UPDATE Quizzes SET QuizName = \"{quiz.Name}\" WHERE Id = {quiz.ID}";

            command.ExecuteNonQuery();
        }

        public static void SaveQuiz(QuizInstance quiz)
        {
            try
            {
                conn.Open();
                SaveQuiz(conn, quiz);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
