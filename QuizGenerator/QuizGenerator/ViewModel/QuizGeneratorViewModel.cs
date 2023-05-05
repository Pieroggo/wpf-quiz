using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using QuizGenerator.Model;

namespace QuizGenerator.ViewModel
{
    internal class QuizGeneratorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private QuizInstance currentQuiz;
        private MainModel model;

        public QuizGeneratorViewModel()
        {
            model = new MainModel();
            DataAccess.ReadData();
            quizList = MainModel.Quizy;
    }

        private ObservableCollection<QuizInstance> quizList;
        public ObservableCollection<QuizInstance> QuizList
        {
            get { return quizList; }
            set
            {
                quizList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizList)));
            }
        }//ten bidning średnio działa, nie wiem czemu...

        private string quizTitle = "Podaj nazwę...";
        public string QuizTitle
        {
            get { return quizTitle; }
            set
            {
                quizTitle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizTitle)));
            }
        }
        private string answerA = "Podaj odpowiedź A...";
        public string AnswerA
        {
            get { return answerA; }
            set
            {
                answerA = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswerA)));
            }
        }
        private string answerB = "Podaj odpowiedź B...";
        public string AnswerB
        {
            get { return answerB; }
            set
            {
                answerB = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswerB)));
            }
        }
        private string answerC = "Podaj odpowiedź C...";
        public string AnswerC
        {
            get { return answerC; }
            set
            {
                answerC = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswerC)));
            }
        }

        private string answerD = "Podaj odpowiedź D...";
        public string AnswerD
        {
            get { return answerD; }
            set
            {
                answerD = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswerD)));
            }

        }
        private string questionName = "Podaj nazwę pytania...";
        public string QuestionName
        {
            get { return questionName; }
            set
            {
                questionName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuestionName)));
            }

        }
        private string quizQuestionAmount = "Ilość pytań: {liczba}";
        public string QuizQuestionAmount
        {
            get { return quizQuestionAmount; }
            set
            {
                quizQuestionAmount  = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizQuestionAmount)));
            }

        }
    }
}
