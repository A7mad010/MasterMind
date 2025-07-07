using System.Collections.Generic;

namespace MasterMind.GameCore
{
    /// <summary>
    /// It allows you to check for many types of input errors.
    /// </summary>
    internal class InputValidator
    {
        private static InputValidator m_instance;
        public static InputValidator Instance
        {
            get
            {
                if(m_instance == null)
                {
                    m_instance = new InputValidator();
                }
                
                return m_instance;
            }
        }

        /// <summary>
        /// It is checked whether the number of characters is equal to the required number.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expectedLength"></param>
        /// <returns></returns>
        public bool IsCorrectLenght(string input, int expectedLength)
        {
            return input.Length == expectedLength;
        }

        /// <summary>
        /// Check if the input value consists of numbers only.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsNumericOnly(string input)
        {
            return int.TryParse(input, out int result);
        }

        /// <summary>
        /// It checks whether there is any repetition in numbers, letters, or anything else.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool HasUniqueDigits(string input)
        {
            HashSet<char> digits = new HashSet<char>();

            foreach (char c in input)
            {
                if (!digits.Add(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
