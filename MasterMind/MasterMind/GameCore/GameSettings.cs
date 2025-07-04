using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace MasterMind.GameCore
{
    /// <summary>
    /// Holds the main game settings, including player name, password, and attempts.
    /// Also provides a method to format and update the player name.
    /// </summary>
    internal class GameSettings
    {
        public string playerName { get; set; }
        public string password { get; private set; }
        public int attempts {  get; private set; }

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

        /// <summary>
        /// Updates the player name by:
        /// - Trimming leading and trailing whitespace
        /// - Converting the name to title case
        /// </summary>
        /// <param name="newPlayerName"></param>
        public void ChangePlayerName(string newPlayerName)
        {
            TextInfo textinfo = CultureInfo.CurrentCulture.TextInfo;

            //Filtering :
            newPlayerName = textinfo.ToTitleCase(newPlayerName);
            newPlayerName = newPlayerName.Trim();

            playerName = newPlayerName;
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
            }
            else
            {
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

            password = newPassword;
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
                return;
            }

            if (intAttempts < 1)
            {
                intAttempts = 1;
            }

            attempts = intAttempts;
        }
    }
}
