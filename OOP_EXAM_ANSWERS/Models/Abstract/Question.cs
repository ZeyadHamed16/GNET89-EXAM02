using OOP_EXAM_ANSWERS.Models.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_EXAM_ANSWERS.Models.Abstract
{
    /// <summary>
    /// Represents the abstract base for all exam questions.
    /// Supports cloning via <see cref="ICloneable"/> and sorting by mark via <see cref="IComparable{T}"/>.
    /// </summary>
    internal abstract class Question : ICloneable , IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public int CorrectAnswerId { get; set; }

        protected Question(string header, string body, int mark, Answer[] answerList, int correctAnswerId)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            CorrectAnswerId = correctAnswerId;
        }

        /// <summary>
        /// Finds and returns the <see cref="Answer"/> matching the specified ID, or <c>null</c> if not found.
        /// </summary>
        public Answer GetAnswerById(int id)
        {
            foreach (Answer answer in AnswerList)
            {
                if (answer.AnswerId == id)
                    return answer;
            }
            return null;
        }

        public Answer GetCorrectAnswer() => GetAnswerById(CorrectAnswerId);

        public bool CheckAnswer(int studentAnswerId) => studentAnswerId == CorrectAnswerId;

        /// <summary>
        /// Displays the question body, header, mark, and all available choices on the console.
        /// </summary>
        public void Show(int questionNumber)
        {
            Console.WriteLine($"Question {questionNumber}: {Body}");
            Console.WriteLine($"{Header}: Mark {Mark}");
            foreach (Answer answer in AnswerList)
            {
                Console.WriteLine(answer.ToString());
            }
        }

        public int AskStudentAnswer()
        {
            Console.WriteLine("Enter your answer ID:");
            return ConsoleHelper.ReadLineRequiredInt();
        }

        public object Clone() => this.MemberwiseClone();

        public int CompareTo(Question other)
        {
            if (other == null) 
                return 1;
            return Mark.CompareTo(other.Mark);
        }

        public override string ToString() => $"{Header} - {Body}";
    }
}
