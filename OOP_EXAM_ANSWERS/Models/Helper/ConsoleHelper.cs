using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_EXAM_ANSWERS.Models.Helper
{
    /// <summary>
    /// Provides static helper methods for reading and validating user inputs from the console.
    /// </summary>
    internal class ConsoleHelper
    {
        /// <summary>
        /// Prompts for input until a non-empty, non-whitespace string is entered.
        /// </summary>
        /// <returns>A valid non-null string provided by the user.</returns>
        public static string ReadLineRequiredString()
        {
            string? input;
            do
            {
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("This field cannot be empty, please try again:");
                }
            }
            while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        /// <summary>
        /// Prompts for input until a valid integer is entered.
        /// </summary>
        /// <returns>The parsed integer value.</returns>
        public static int ReadLineRequiredInt()
        {
            int value;
            string? input;
            bool isValid;

            do
            {
                input = Console.ReadLine();
                isValid = int.TryParse(input, out value);

                if (!isValid)
                {
                    Console.WriteLine("Invalid input, please enter a number:");
                }
            }
            while (!isValid);

            return value;
        }
    }
}
