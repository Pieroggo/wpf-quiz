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
        public string QuestionText { get { return _questionText; } }
        private string _answer1;
        public string Answer1 { get {  return _answer1; } }
        private string _answer2;
        public string Answer2 { get { return _answer2; } }
        private string _answer3;
        public string Answer3 { get { return _answer3; } }
        private string _answer4;
        public string Answer4 { get { return _answer4; } }
        private long _rightAnswer;
        public bool[] Answers= { false, false, false, false };

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
            ListifyCorrectness();
        }
        private void ListifyCorrectness() {
            if (_rightAnswer > 7) { Answers[0] = true; }
            if (_rightAnswer % 8 > 3) { Answers[1] = true; }
            if (_rightAnswer % 4 > 1) { Answers[2]= true; }
            if (_rightAnswer % 2 == 1) { Answers[3] = true; }  
        }
        public override string ToString()
        {
            return "Pytanie " + id + ": " + _questionText + " A: " + _answer1 + " B: " + _answer2 + " C: " + _answer3 + " D: " + _answer4 + " RightAnswerInteger: " + _rightAnswer;
        }
    }
}
