﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.DTOs
{
    public class CreateQuestionDTO
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public string AnswerText { get; set; }
    }
}
