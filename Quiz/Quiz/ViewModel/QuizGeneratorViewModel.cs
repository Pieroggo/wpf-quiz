using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFQuiz.ViewModel
{
    internal class QuizGeneratorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Quiz currentQuiz;
        
        //flagi akcji
        private static bool isQuizOpen = true;
        private static bool isGeneratorOpen = false;
        private VisibilityViewModel vvm = new VisibilityViewModel();
        public QuizGeneratorViewModel() { }
        
       

    }
}
