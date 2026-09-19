using OOP_EXAM_ANSWERS.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_EXAM_ANSWERS.Models
{
    /// <summary>
    /// Represents a True/False question, automatically initializing its choices with <c>1-True</c> and <c>2-False</c>.
    /// </summary>
    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string body, int mark, int correctAnswerId) : base("True | False Question", body, mark, new Answer[] { new Answer(1, "True"), new Answer(2, "False") }, correctAnswerId)
        {
        }
    }
}
