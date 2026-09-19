using OOP_EXAM_ANSWERS.Models.Abstract;
using OOP_EXAM_ANSWERS.Models.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_EXAM_ANSWERS.Models
{
    /// <summary>
    /// Represents an academic subject, managing its associated exam creation and setup.
    /// </summary>
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam ExamOfSubject { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        /// <summary>
        /// Prompts user input to configure exam parameters (type, time, questions) and builds the associated <see cref="Exam"/>.
        /// </summary>
        public void CreateExam()
        {
            Console.WriteLine($"Subject: {SubjectName}");
            Console.WriteLine("=============================");
            Console.WriteLine();

            Console.WriteLine("Enter the type of exam (1 for Practical, 2 for Final):");
            int examType = ConsoleHelper.ReadLineRequiredInt();

            int time = 0;
            do
            {
                Console.WriteLine("Please enter the time for the exam (30 to 180 minutes):");
                time = ConsoleHelper.ReadLineRequiredInt();
            }
            while (time < 30 || time > 180);

            Console.WriteLine("Please enter the number of questions:");
            int numberOfQuestions = ConsoleHelper.ReadLineRequiredInt();


            Exam exam;
            if (examType == 1)
                exam = new PracticalExam(time, numberOfQuestions);
            else
                exam = new FinalExam(time, numberOfQuestions);


            Console.Clear(); // for just user friendly

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"Enter details for question {i + 1}:");

                Question question;
                if (examType == 1)
                {
                    question = CreateMCQQuestion();
                }
                else
                {
                    Console.WriteLine("Choose question type: 1 for MCQ, 2 for True/False:");
                    int questionType = ConsoleHelper.ReadLineRequiredInt();

                    if (questionType == 1)
                    {
                        question = CreateMCQQuestion();
                    }
                    else
                    {
                        question = CreateTrueFalseQuestion();
                    }
                }
                exam.Questions.Add(question);
            }
            ExamOfSubject = exam;
        }

        private Question CreateMCQQuestion()
        {
            Console.WriteLine("Please enter the question body:");
            string body = ConsoleHelper.ReadLineRequiredString();

            Console.WriteLine("Please enter the question mark:");
            int mark = ConsoleHelper.ReadLineRequiredInt();

            Console.WriteLine("Choices of Question:");
            Answer[] answers = new Answer[4];
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Please enter choice number {i + 1}:");
                string choiceText = ConsoleHelper.ReadLineRequiredString();
                answers[i] = new Answer(i + 1, choiceText);
            }

            Console.WriteLine("Please enter the ID of the correct answer (1 to 4):");
            int correctAnswerId = ConsoleHelper.ReadLineRequiredInt();

            Console.Clear(); // for just user friendly

            return new MCQQuestion(body, mark, answers, correctAnswerId);
        }

        private static Question CreateTrueFalseQuestion()
        {
            Console.WriteLine("Please enter the question body:");
            string body = ConsoleHelper.ReadLineRequiredString();

            Console.WriteLine("Please enter the question mark:");
            int mark = ConsoleHelper.ReadLineRequiredInt();

            Console.WriteLine("Please enter the ID of the correct answer (1 for True, 2 for False):");
            int correctAnswerId = ConsoleHelper.ReadLineRequiredInt();

            Console.Clear(); // for just user friendly

            return new TrueFalseQuestion(body, mark, correctAnswerId);
        }

    }
}
