using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using QuizGenerator.Model;

namespace QuizGenerator.Model
{
    internal class QuizInstance
    {
        private long id;
        public long ID { get { return id; } }
        private string _name;
        private ObservableCollection<Question> questions;
        public ObservableCollection<Question> Questions { get { return questions; } }
        public QuizInstance() {
            id = -1;
            _name = "Something went wrong";
            questions = new ObservableCollection<Question>();
        }
        public QuizInstance(long id, string name, ObservableCollection<Question> questions)
        {
            this.id = id;
            _name = name;
            this.questions = questions;
        }
        public string ToString()
        {
            string str="Quiz " + id + " - " + _name + " :\n";
            foreach(var item in questions)
            {
                str += item.ToString()+"\n";
            }
            return str;
        }
    }

}
