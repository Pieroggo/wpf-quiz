﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WPFQuiz.Model;

namespace WPFQuiz.Model
{
    internal class QuizInstance
    {
        private long id;
        public long ID { get { return id; } }
        private string _name;
        public string Name { get { return _name; } }
        private ObservableCollection<Question> questions;
        public ObservableCollection<Question> Questions { get { return questions; } }
        public QuizInstance()
        {
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
        public override string ToString()
        {
            string str = "Quiz " + id + " - " + _name;
            return str;
        }
    }

}
