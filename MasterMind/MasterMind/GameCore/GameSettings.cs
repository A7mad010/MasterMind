using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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
            //Filtering :
            newPassword = newPassword.Trim();

            password = newPassword;
        }

        /// Updates the number of attempts by:
        /// - Setting it to the new value provided
        /// - Ensuring the value is never less than 1 (minimum is 1)
        /// <param name="newAttempts"></param>
        public void ChangeAttempts(int newAttempts)
        {
            if(newAttempts < 1)
            {
                newAttempts = 1;
            }

            attempts = newAttempts;
        }
    }
}
