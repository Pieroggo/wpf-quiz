using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private MainModel model;
        private System.Timers.Timer quizTimer;

        public QuizViewModel()
        {
            model = new MainModel();
            quizTimer = new System.Timers.Timer(1000);
            DataAccess.ReadData();
            quizList = MainModel.Quizy;
        }
        private ObservableCollection<QuizInstance> quizList = new ObservableCollection<QuizInstance>();
        public ObservableCollection<QuizInstance> QuizList
        {
            get { return quizList; }
            set
            {
                quizList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizList)));
            }
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
        public void ReloadQuizList() { quizList = MainModel.Quizy; }
        private ICommand onSelectionChanged;
        public ICommand OnSelectionChanged {

            get; set;
        }
        

    }
}
