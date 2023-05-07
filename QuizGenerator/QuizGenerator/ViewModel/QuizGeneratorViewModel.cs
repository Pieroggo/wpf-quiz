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
        }

        private ObservableCollection<Question> questionList;
        public ObservableCollection<Question> QuestionList
        {
            get { return questionList; }
            set
            {
                questionList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuestionList)));
            }
        }

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
        private bool answerAchecked = false;
        public bool AnswerAchecked
        {
            get { return answerAchecked; }
            set
            {
                answerAchecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswerAchecked)));
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
        private bool answerBchecked = false;
        public bool AnswerBchecked
        {
            get { return answerBchecked; }
            set
            {
                answerBchecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswerBchecked)));
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
        private bool answerCchecked = false;
        public bool AnswerCchecked
        {
            get { return answerCchecked; }
            set
            {
                answerCchecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswerCchecked)));
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
        private bool answerDchecked = false;
        public bool AnswerDchecked
        {
            get { return answerDchecked; }
            set
            {
                answerDchecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswerDchecked)));
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

        private ICommand addEmptyQuiz;
        public ICommand AddEmptyQuiz
        {
            get 
            { 
                if (addEmptyQuiz == null)
                {
                    addEmptyQuiz = new RelayCommand(
                        (o) =>
                        {
                            MainModel.MakeNewQuiz(QuizList.Count()+1, "Pusty Quiz");
                        },
                        (o) => true
                        );
                }

                return addEmptyQuiz; 
            }
        }

        private QuizInstance selectedQuiz;
        public QuizInstance SelectedQuiz
        {
            get { return selectedQuiz; }
            set
            {
                selectedQuiz = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedQuiz)));
            }
        }

        private Question selectedQuestion;
        public Question SelectedQuestion
        {
            get { return selectedQuestion; }
            set
            {
                selectedQuestion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedQuestion)));
            }
        }



        private ICommand setQuiz;
        public ICommand SetQuiz
        {
            get
            {
                if (setQuiz == null)
                {
                    setQuiz = new RelayCommand(
                        (o) =>
                        {
                            currentQuiz = SelectedQuiz;
                            QuestionList = currentQuiz.Questions;

                            QuizTitle = currentQuiz.Name;

                            AnswerAchecked = false; AnswerBchecked = false; AnswerCchecked = false; AnswerDchecked = false;
                        },
                        (o) => true
                        );
                }

                return setQuiz;
            }
        }

        private ICommand setQuestion;
        public ICommand SetQuestion
        {
            get
            {
                if (setQuestion == null)
                {
                    setQuestion = new RelayCommand(
                        (o) =>
                        {
                            AnswerA = SelectedQuestion.Answer1;
                            AnswerB = SelectedQuestion.Answer2;
                            AnswerC = SelectedQuestion.Answer3;
                            AnswerD = SelectedQuestion.Answer4;

                            QuestionName = SelectedQuestion.QuestionText;

                            long number = SelectedQuestion.RightAnswer;
                            string binaryString = Convert.ToString(number, 2).PadLeft(4, '0'); ;
                            
                            if (binaryString[0] == '1')
                            {
                                AnswerAchecked = true;
                            } 
                            else
                            {
                                AnswerAchecked = false;
                            }

                            if (binaryString[1] == '1')
                            {
                                AnswerBchecked = true;
                            }
                            else
                            {
                                AnswerBchecked = false;
                            }

                            if (binaryString[2] == '1')
                            {
                                AnswerCchecked = true;
                            }
                            else
                            {
                                AnswerCchecked = false;
                            }

                            if (binaryString[3] == '1')
                            {
                                AnswerDchecked = true;
                            }
                            else
                            {
                                AnswerDchecked = false;
                            }
                        },
                        (o) => true
                        );
                }

                return setQuestion;
            }
        }
    }
}
