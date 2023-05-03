using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFQuiz;
using WPFQuiz.ViewModel;

namespace WPFQuiz.ViewModel
{
    internal class VisibilityViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
        //flagi akcji
        private static bool isQuizOpen = true;
        private static bool isGeneratorOpen = false;

        private Visibility quizVisibility = Visibility.Visible;
        public Visibility QuizVisibility
        {
            get => quizVisibility;
            set
            {
                quizVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizVisibility)));
            }
        }
        private static Visibility generatorVisibility = Visibility.Visible;
        public Visibility GeneratorVisibility
        {
            get => generatorVisibility;
            set
            {
                generatorVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GeneratorVisibility)));
            }
        }
        private ICommand openGenerator;
        public ICommand OpenGenerator
        {

            get
            {
                if (openGenerator == null)
                    openGenerator = new RelayCommand(

                    (o) =>
                    {
                        QuizVisibility = Visibility.Hidden;
                        GeneratorVisibility = Visibility.Visible;
                        isGeneratorOpen = true;
                        isQuizOpen = false;
                    }
                    ,
                    (o) => !isGeneratorOpen
                    );
                return openGenerator;
            }
        }
        private ICommand openQuiz;
        public ICommand OpenQuiz
        {

            get
            {
                if (openQuiz == null)
                    openQuiz = new RelayCommand(

                    (o) =>
                    {
                        QuizVisibility = Visibility.Visible;
                        GeneratorVisibility = Visibility.Hidden;
                        isGeneratorOpen = false;
                        isQuizOpen = true;
                    }
                    ,
                    (o) => !isGeneratorOpen
                    );
                return openQuiz;
            }
        }

    }
}
