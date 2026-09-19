using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_EXAM_ANSWERS.Models
{
    /// <summary>
    /// Represents a single selectable choice belonging to a <see cref="Abstract.Question"/>.
    /// </summary>
    /// <remarks>
    /// Overrides <see cref="ToString"/> to format the answer as <c>"Id - Text"</c> (e.g., <c>"1 - True"</c>).
    /// </remarks>
    internal class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int answerID, string answerText)
        {
            AnswerId = answerID;
            AnswerText = answerText;
        }

        public override string ToString()
        {
            return $"{AnswerId} - {AnswerText}";
        }
    }
}
