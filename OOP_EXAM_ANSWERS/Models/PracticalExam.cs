using OOP_EXAM_ANSWERS.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_EXAM_ANSWERS.Models
{
    /// <summary>
    /// Represents a practical exam consisting only of multiple-choice questions (MCQ).
    /// </summary>
    internal class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            ShowExamCommon("Practical Exam", "Practical Exam Results:");
        }
    }
}
