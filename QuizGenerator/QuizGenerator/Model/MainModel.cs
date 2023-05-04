using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

using QuizGenerator.Model;

namespace QuizGenerator.Model
{
    internal class MainModel
    {
        private static ObservableCollection<QuizInstance> _quizy;
        public static ObservableCollection<QuizInstance> Quizy
        {
            get { return _quizy; }
        }
        public MainModel() { _quizy = new ObservableCollection<QuizInstance>(); }
        public MainModel(ObservableCollection<QuizInstance> list) { _quizy = list; }
        public static void MakeNewQuiz(long id, string quizName)
        {
            QuizInstance newQuiz = new QuizInstance(id,quizName,new ObservableCollection<Question>());
            _quizy.Add(newQuiz);
        }
        public static void InsertQuestion(Question question, long targetQuizId)
        {
            foreach(var quiz in _quizy)
            {
                if (targetQuizId == quiz.ID) {
                    quiz.Questions.Add(question);
                }
            }

        }
        public static string ReturnContentString() {
            string ret = "";
            foreach (var quiz in _quizy) {
                ret += quiz.ToString();
            }
            return ret;
        }
    }
}
