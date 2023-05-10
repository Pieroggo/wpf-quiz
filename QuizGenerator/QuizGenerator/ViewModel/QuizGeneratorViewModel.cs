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
            DataAccess.ReadQuizes();
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
                            long quizidtmp = QuizList[QuizList.Count() - 1].ID + 1;
                            MainModel.MakeNewQuiz(quizidtmp, QuizTitle);
                            DataAccess.InsertNewQuiz(quizidtmp, QuizTitle);
                        },
                        (o) => true
                        );
                }

                return addEmptyQuiz; 
            }
        }

        private ICommand dropQuiz;
        public ICommand DropQuiz
        {
            get
            {
                if (dropQuiz == null)
                {
                    dropQuiz = new RelayCommand(
                        (o) =>
                        {
                            DataAccess.DropQuiz(SelectedQuiz);
                            MainModel.RemoveQuiz(SelectedQuiz);
                        },
                        (o) => true
                        );
                }

                return dropQuiz;
            }
        }

        private ICommand addEmptyQuestion;
        public ICommand AddEmptyQuestion
        {
            get
            {
                if (addEmptyQuestion == null)
                {
                    addEmptyQuestion = new RelayCommand(
                        (o) =>
                        {
                            string binaryString = "";

                            if (answerAchecked)
                            {
                                binaryString += '1';
                            }
                            else
                            {
                                binaryString += '0';
                            }

                            if (answerBchecked)
                            {
                                binaryString += '1';
                            }
                            else
                            {
                                binaryString += '0';
                            }

                            if (answerCchecked)
                            {
                                binaryString += '1';
                            }
                            else
                            {
                                binaryString += '0';
                            }

                            if (answerDchecked)
                            {
                                binaryString += '1';
                            }
                            else
                            {
                                binaryString += '0';
                            }

                            int number = Convert.ToInt32(binaryString, 2);

                            MainModel.InsertQuestion(new Question(0, QuestionName, AnswerA, AnswerB, AnswerC, AnswerD, number), currentQuiz.ID);
                            DataAccess.InsertNewQuestion(QuestionName, AnswerA, AnswerB, AnswerC, AnswerD, number, currentQuiz);
                        },
                        (o) => true
                        );
                }

                return addEmptyQuestion;
            }
        }

        private ICommand dropQuestion;
        public ICommand DropQuestion
        {
            get
            {
                if (dropQuestion == null)
                {
                    dropQuestion = new RelayCommand(
                        (o) =>
                        {
                            DataAccess.DropQuestion(SelectedQuestion, currentQuiz);
                            MainModel.RemoveQuestion(SelectedQuestion, currentQuiz.ID);
                        },
                        (o) => true
                        );
                }

                return dropQuestion;
            }
        }

        private ICommand saveQuestion;
        public ICommand SaveQuestion
        {
            get
            {
                if (saveQuestion == null)
                {
                    saveQuestion = new RelayCommand(
                        (o) =>
                        {
                            string oldText = SelectedQuestion.QuestionText;
                            SelectedQuestion.QuestionText = QuestionName;
                            SelectedQuestion.Answer1 = AnswerA;
                            SelectedQuestion.Answer2 = AnswerB;
                            SelectedQuestion.Answer3 = AnswerC;
                            SelectedQuestion.Answer4 = AnswerD;

                            string binaryString = "";

                            if (answerAchecked)
                            {
                                binaryString += '1';
                            }
                            else
                            {
                                binaryString += '0';
                            }

                            if (answerBchecked)
                            {
                                binaryString += '1';
                            }
                            else
                            {
                                binaryString += '0';
                            }

                            if (answerCchecked)
                            {
                                binaryString += '1';
                            }
                            else
                            {
                                binaryString += '0';
                            }

                            if (answerDchecked)
                            {
                                binaryString += '1';
                            }
                            else
                            {
                                binaryString += '0';
                            }

                            int number = Convert.ToInt32(binaryString, 2);

                            SelectedQuestion.RightAnswer = number;

                            DataAccess.SaveQuestion(SelectedQuestion, currentQuiz, oldText);
                            currentQuiz.Questions.Clear();
                            QuestionList = currentQuiz.Questions;
                            DataAccess.ReadQuestionsForQuiz(currentQuiz);
                        },
                        (o) => true
                        );
                }

                return saveQuestion;
            }
        }

        private ICommand saveQuiz;
        public ICommand SaveQuiz
        {
            get
            {
                if (saveQuiz == null)
                {
                    saveQuiz = new RelayCommand(
                        (o) =>
                        {
                            currentQuiz.Name = QuizTitle;
                            DataAccess.SaveQuiz(currentQuiz);
                            MainModel.Quizy.Clear();
                            DataAccess.ReadQuizes();

                        },
                        (o) => true
                        );
                }

                return saveQuiz;
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

                            DataAccess.ReadQuestionsForQuiz(currentQuiz);

                            QuestionList = currentQuiz.Questions;

                            QuizTitle = currentQuiz.Name;

                            AnswerAchecked = false; AnswerBchecked = false; AnswerCchecked = false; AnswerDchecked = false;

                            QuizQuestionAmount = $"Ilość pytań: {QuestionList.Count()}";
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

        private ICommand resetAnswers;
        public ICommand ResetAnswers
        {
            get
            {
                if (resetAnswers == null)
                {
                    resetAnswers = new RelayCommand(
                        (o) =>
                        {
                            AnswerAchecked = false;
                            AnswerBchecked = false;
                            AnswerCchecked = false;
                            AnswerDchecked = false;

                        },
                        (o) => true
                        );
                }

                return resetAnswers;
            }
        }
    }
}
