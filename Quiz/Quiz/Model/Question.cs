using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFQuiz.Model
{
    internal class Question
    {
        private long id;
        private string _questionText;
        private string _answer1;
        private string _answer2;
        private string _answer3;
        private string _answer4;
        private long _rightAnswer;

        public Question()
        {
            id = -1;
            _questionText = "Something went wrong";
            _answer1 = "";
            _answer2 = "";
            _answer3 = "";
            _answer4 = "";
            _rightAnswer = 0;

        }
        public Question(long id, string qText, string a1, string a2, string a3, string a4, long right)
        {
            this.id = id;
            _questionText = qText;
            _answer1 = a1;
            _answer2 = a2;
            _answer3 = a3;
            _answer4 = a4;
            _rightAnswer = right;
        }
        public override string ToString()
        {
            return "Pytanie " + id + ": " + _questionText + " A: " + _answer1 + " B: " + _answer2 + " C: " + _answer3 + " D: " + _answer4 + " RightAnswerInteger: " + _rightAnswer;
        }
    }
}
