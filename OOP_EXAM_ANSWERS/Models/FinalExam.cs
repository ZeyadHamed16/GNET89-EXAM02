using OOP_EXAM_ANSWERS.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_EXAM_ANSWERS.Models
{
    /// <summary>
    /// Represents a final exam that can contain both MCQ and True/False questions.
    /// </summary>
    internal class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            ShowExamCommon("Final Exam", "Final Exam Results:");
        }
    }
}
