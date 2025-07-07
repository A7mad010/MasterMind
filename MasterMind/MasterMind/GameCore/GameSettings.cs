using System;
using System.Linq;

namespace MasterMind.GameCore
{
    /// <summary>
    /// Holds the main game settings, including player name, password, and attempts.
    /// Also provides a method to format and update the player name.
    /// </summary>
    internal class GameSettings
    {
        public string password { get; private set; } = "";
        public int attempts { get; private set; } = 8;

        private static GameSettings m_instance;
        private InputValidator inputValidator = InputValidator.Instance;

        //Singleton Class
        public static GameSettings Instance
        {
            get
            {
                if(m_instance == null)
                {
                    m_instance = new GameSettings();
                }

                return m_instance;
            }
        }

        /// Updates the password by:
        /// - Trimming leading and trailing whitespace
        /// <param name="newPassword"></param>
        public void ChangePassword(string newPassword)
        {
            newPassword = newPassword.Trim();

            if(inputValidator.IsNumericOnly(newPassword) && inputValidator.IsCorrectLenght(newPassword,4) && inputValidator.HasUniqueDigits(newPassword))
            {
                password = newPassword;
                MassagePro.Text("The password has been changed successfully.", ConsoleColor.Green, 5);
            }
            else
            {
                MassagePro.Text("An error occurred you cannot change the password.", ConsoleColor.Red, 5);
                return;
            }
        }

        /// <summary>
        /// Use to generate pssword (Random)
        /// </summary>
        public void RandomPassword()
        {
            Random random = new Random();
            string newPassword = "";

            while (newPassword.Length < 4)
            {
                char digit = random.Next(0, 10).ToString()[0];

                if (!newPassword.Contains(digit))
                {
                    newPassword += digit;
                }
            }

            ChangePassword(newPassword);
        }

        /// Updates the number of attempts by:
        /// - Setting it to the new value provided
        /// - Ensuring the value is never less than 1 (minimum is 1)
        /// <param name="newAttempts"></param>
        public void ChangeAttempts(string newAttempts)
        {
            int intAttempts = 0;

            if (inputValidator.IsNumericOnly(newAttempts))
            {
                intAttempts = Convert.ToInt16(newAttempts);
            }
            else
            {
                MassagePro.Text($"You can only enter numbers.", ConsoleColor.Red, 5);
                return;
            }

            if (intAttempts < 1)
            {
                intAttempts = 1;
            }

            attempts = intAttempts;
            MassagePro.Text($"The number of attempts has been changed to {attempts} attempts",ConsoleColor.Green,5);
        }
    }

}
