using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using WPFQuiz.Model;

namespace WPFQuiz.ViewModel
{
    internal class QuizViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private QuizInstance currentQuiz;
        private int correctAnswers;
        private System.Timers.Timer quizTimer;

        public QuizViewModel()
        {
            quizTimer = new System.Timers.Timer(1000);

            DataAccess.ReadData();
        }
        private string quizTitle = "Quiz: {nazwa quizu}";
        public string QuizTitle
        {
            get => quizTitle;
            set
            {
                quizTitle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizTitle)));
            }
        }
        private string score = "Wynik: {wynik}";
        public string Score
        {
            get => score;
            set
            {
                score = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Score)));
            }
        }
        private string quizTime = "Wynik: {wynik}";
        public string QuizTime
        {
            get => quizTime;
            set
            {
                quizTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizTime)));
            }
        }
        

        

    }
}
