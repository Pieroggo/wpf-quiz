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
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using WPFQuiz.Model;

namespace WPFQuiz.ViewModel
{
    internal class QuizViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private QuizInstance currentQuiz;
        private int currentQuestionIndex=0;
        private static bool quizOn;
        private static bool questionChecked = true;
        private int correctAnswers=0;
        private MainModel model;
        private System.Timers.Timer quizTimer;
        private int quizTimeMinutes=0;
        private int quizTimeSeconds=0;

        public QuizViewModel()
        {
            model = new MainModel();
            quizTimer = new System.Timers.Timer(1000);
            quizTimer.Elapsed += onTimerElapsed;
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

        private string quizTime = "Czas: {czas}";
        public string QuizTime
        {
            get => quizTime;
            set
            {
                quizTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizTime)));
            }
        }
        private string currentQuestionText = "{pytanie}";
        public string CurrentQuestionText
        {
            get => currentQuestionText;
            set
            {
                currentQuestionText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentQuestionText)));
            }
        }
        private string currentAnswerA = "{Odpowiedź A}";
        public string CurrentAnswerA
        {
            get => currentAnswerA;
            set
            {
                currentAnswerA = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentAnswerA)));
            }
        }
        private string currentAnswerB = "{Odpowiedź B}";
        public string CurrentAnswerB
        {
            get => currentAnswerB;
            set
            {
                currentAnswerB = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentAnswerB)));
            }
        }
        private string currentAnswerC = "{Odpowiedź C}";
        public string CurrentAnswerC
        {
            get => currentAnswerC;
            set
            {
                currentAnswerC = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentAnswerC)));
            }
        }
        private string currentAnswerD = "{Odpowiedź D}";
        public string CurrentAnswerD
        {
            get => currentAnswerD;
            set
            {
                currentAnswerD = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentAnswerD)));
            }
        }
        private bool checkedA = false;
        public bool CheckedA
        {
            get => checkedA;
            set
            {
                checkedA = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckedA)));
            }
        }
        private bool checkedB = false;
        public bool CheckedB
        {
            get => checkedB;
            set
            {
                checkedB = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckedB)));
            }
        }
        private bool checkedC = false;
        public bool CheckedC
        {
            get => checkedC;
            set
            {
                checkedC = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckedC)));
            }
        }
        private bool checkedD = false;
        public bool CheckedD
        {
            get => checkedD;
            set
            {
                checkedD = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckedD)));
            }
        }
        private bool startEnabled = false;
        public bool StartEnabled
        {
            get { return startEnabled; }
            set { startEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartEnabled))); }
        }
        private bool stopEnabled = false;
        public bool StopEnabled
        {
            get { return stopEnabled; }
            set
            {
                stopEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StopEnabled)));
            }
        }
        private bool quizInPlay = false;
        public bool QuizInPlay
        {
            get { return quizInPlay; }
            set
            {
                quizInPlay = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizInPlay)));
            }
        }
        private QuizInstance selectedQuiz = null;
        public QuizInstance SelectedQuiz
        {
            get {return selectedQuiz; }
        
        set {selectedQuiz=value;
                if(selectedQuiz != null) { StartEnabled = true;}

                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(SelectedQuiz)));}
        }

        private ICommand startQuiz;
        public ICommand StartQuiz
        {
            get
            {
                if (startQuiz == null)
                    startQuiz = new RelayCommand(

                    (o) =>
                    {
                        currentQuiz = SelectedQuiz;
                        QuizTitle = "Quiz: "+currentQuiz.Name;
                        correctAnswers = 0;
                        ReloadScore();
                        if (quizTimeSeconds < 10) { QuizTime = "Czas: " + quizTimeMinutes + ":0" + quizTimeSeconds; }
                        else { QuizTime = "Czas: " + quizTimeMinutes + ":" + quizTimeSeconds; }
                        currentQuestionIndex = 0;
                        NextQuestion(currentQuestionIndex);
                        quizTimer?.Start();
                        quizOn = true;
                        StartEnabled = false;
                        StopEnabled = true;
                        QuizInPlay = true;
                        questionChecked = false;
                        Console.WriteLine("Quiz Start");
                    }
                    ,
                    (o) => !quizOn
                     );
                return startQuiz;
            }

        }
        private ICommand stopQuiz;
        public ICommand StopQuiz
        {
            get {
                if (stopQuiz == null)
                {
                    stopQuiz = new RelayCommand(


                    (o) =>
                    {
                        QuizStop();
                    }
                    ,
                    (o) => quizOn
                     );
                }
                    return stopQuiz;
                }
            
        }
        private ICommand checkQuestion;
        public ICommand CheckQuestion
        {
            get
            {
                if (checkQuestion == null)
                {
                    checkQuestion = new RelayCommand(


                    (o) =>
                    {
                        
                        bool correct=true;
                        bool[] answers = currentQuiz.Questions.ElementAt(currentQuestionIndex).Answers;
                        bool[] formState = new bool[] { CheckedA, CheckedB, CheckedC, CheckedD };
                        int i = 0;
                        while (i < answers.Length)
                        {
                            if (answers[i] != formState[i]) { correct = false; }
                            i++;
                        }
                        if (correct) { correctAnswers++; }
                        ReloadScore();
                        Console.WriteLine("Question "+(currentQuestionIndex+1)+" checked");
                        questionChecked = true;
                    }
                    ,
                    (o) => !questionChecked
                     );
                }
                return checkQuestion;
            }

        }
        private ICommand nextQuestionCommand;
        public ICommand NextQuestionCommand
        {
            get
            {
                if (nextQuestionCommand == null)
                    nextQuestionCommand = new RelayCommand(

                    (o) =>
                    {
                        currentQuestionIndex++;
                        NextQuestion(currentQuestionIndex);
                        questionChecked = false;
                    }
                    ,
                    (o) => questionChecked
                     ) ;
                return nextQuestionCommand;
            }

        }
        public void ReloadQuizList() { quizList = MainModel.Quizy; }
        public void ReloadScore() { Score = "Wynik: " + correctAnswers + "/" + currentQuiz.Questions.Count; }
        public void NextQuestion(int i) {
            if (currentQuiz.Questions.Count > i)
            {
                Question question = currentQuiz.Questions.ElementAt(i);
                CurrentQuestionText = question.QuestionText;
                CurrentAnswerA = question.Answer1;
                CurrentAnswerB = question.Answer2;
                CurrentAnswerC = question.Answer3;
                CurrentAnswerD = question.Answer4;
                CheckedA = false; CheckedB=false; CheckedC = false; CheckedD = false;
                string correct = "";
                int j = 1;
                foreach (var a in question.Answers) { Console.WriteLine(a); if (a==true) {correct += j.ToString()+" "; }j++; }
                Console.WriteLine("Next Question - correct: "+correct);

            }
            else {
                QuizStop();
            }
        }
        public void QuizStop() {
            currentQuiz = null;
            quizTimer.Stop();
            quizTimeMinutes = 0;
            quizTimeSeconds = 0;
            quizOn = false;
            StartEnabled = true;
            StopEnabled = false;
            QuizInPlay = false;
            Console.WriteLine("Quiz Stop");

        }
        public void onTimerElapsed(object sender, ElapsedEventArgs e) { quizTimeSeconds++;
            if (quizTimeSeconds >= 60) { quizTimeMinutes++;quizTimeSeconds = 0;
            }
            if (quizTimeSeconds < 10) { QuizTime = "Czas: " + quizTimeMinutes + ":0" + quizTimeSeconds; }
            else { QuizTime = "Czas: " + quizTimeMinutes + ":" + quizTimeSeconds; }
            Console.WriteLine(quizTimeMinutes + ":" + quizTimeSeconds);
        }
        //w skrócie zamiast selectionChanged, guzik sprawdza SelectedItem i go przesyła dalej
        //TODO:
        //1. guzik następne pytanie (nawet ok)
        //2. sprawdzanie odpowiedzie, zmiana backgroundu textBoxów z odp na zielony/czerwony w zależnośći od tego czy prawidłowo zaznaczone (do interpretacji) (jest najprościej jak na razie, inkrementacja wyniku)
        //3. update'owanie wyniku (done)
        //4. screen z zakończeniem quizu (niewidoczny na początek, pokazuje sie jak wszystkie pytania się skończą
        //5. Błędy do wyłapania

    }
}
