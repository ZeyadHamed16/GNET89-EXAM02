using OOP_EXAM_ANSWERS.Models;
using OOP_EXAM_ANSWERS.Models.Helper;

namespace OOP_EXAM_ANSWERS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            * Thank you for reviewing the code.
            * This program demonstrates the exam management system process.
            */

            Subject subject = new Subject(1, "OOP");
            subject.CreateExam();

            Console.WriteLine("Do You Want To Start Exam (Y | N)");
            string choice = ConsoleHelper.ReadLineRequiredString();

            if (choice.Trim().ToUpper() == "Y")
            {
                subject.ExamOfSubject.ShowExam();
            }
            else
            {
                Console.WriteLine("Exam cancelled. Thank you.");
            }
        }
    }
}
