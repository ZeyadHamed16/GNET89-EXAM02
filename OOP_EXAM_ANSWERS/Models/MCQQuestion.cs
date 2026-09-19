using OOP_EXAM_ANSWERS.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_EXAM_ANSWERS.Models
{
    /// <summary>
    /// Represents a Multiple-Choice Question (MCQ) with custom choices and a predefined correct answer.
    /// </summary>
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string body, int mark, Answer[] answerList, int correctAnswerId) : base("MCQ Question", body, mark, answerList, correctAnswerId)
        {
        }
    }
}
