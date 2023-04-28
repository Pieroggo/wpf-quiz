using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Quiz.View
{
    /// <summary>
    /// Logika interakcji dla klasy Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        public Quiz()
        {
            InitializeComponent();
        }
    }
    //Quiz: baza danych
    //Tabela: Quiz ->(Id,Nazwa)
    //        Pytania -> (Id,Nazwa, Odp1,Odp2,Odp3,Odp4,WłaściwaOdp(binarna liczba),IdQuiz)
    //        
}
