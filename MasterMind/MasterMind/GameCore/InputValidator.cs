using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.GameCore
{
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

        public bool IsCorrectLenght(string input, int expectedLength)
        {
            return input.Length == expectedLength;
        }
        public bool IsNumericOnly(string input)
        {
            return int.TryParse(input, out int result);
        }
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
