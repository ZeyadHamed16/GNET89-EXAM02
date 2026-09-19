using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OOP_EXAM_ANSWERS.Models.Abstract
{
    /// <summary>
    /// Represents the abstract base class for all exams, managing exam properties, questions, and timing.
    /// </summary>
    internal abstract class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }

        protected Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new List<Question>();
        }

        /// <summary>
        /// Displays the exam and handles student interactions based on the specific exam type.
        /// </summary>
        public abstract void ShowExam();

        /// <summary>
        /// Arranges the full exam process: runs questions, evaluates answers, calculates scores, and displays final results.
        /// </summary>
        protected void ShowExamCommon(string examTitle, string resultsTitle)
        {
            Console.Clear(); // for just user friendly

            Console.WriteLine(examTitle);

            List<int> studentAnswers = new List<int>();
            TimeSpan examTime = RunExamAndCollectAnswers(studentAnswers);

            Console.WriteLine();
            Console.Clear(); // for just user friendly
            Console.WriteLine(resultsTitle);

            int totalMark = 0;
            int MaxMark = 0;

            for (int i = 0; i < Questions.Count; i++)
            {
                Question question = Questions[i];
                Answer studentAnswer = question.GetAnswerById(studentAnswers[i]);
                Answer correctAnswer = question.GetCorrectAnswer();

                Console.WriteLine($"Question {i + 1}: {question.Body}");
                Console.WriteLine($"Your Answer => {studentAnswer?.AnswerText}");
                Console.WriteLine($"Correct Answer => {correctAnswer?.AnswerText}");
                Console.WriteLine();

                MaxMark += question.Mark;
                if (question.CheckAnswer(studentAnswers[i]))
                {
                    totalMark += question.Mark;
                }
            }

            Console.WriteLine($"Your Grade is {totalMark} from {MaxMark}");
            Console.WriteLine($"Time = {examTime}");
            Console.WriteLine("Thank you");
        }

        /// <summary>
        /// Iterates through questions sequentially, collects student inputs, and measures the elapsed exam duration.
        /// </summary>
        /// <param name="studentAnswers">The list to be populated with the student's selected answer IDs.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the total time taken to complete the exam.</returns>
        public TimeSpan RunExamAndCollectAnswers(List<int> studentAnswers)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int questionNumber = 1;
            foreach (Question question in Questions)
            {
                question.Show(questionNumber);
                int studentAnswerId = question.AskStudentAnswer();
                studentAnswers.Add(studentAnswerId);
                questionNumber++;
            }

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
