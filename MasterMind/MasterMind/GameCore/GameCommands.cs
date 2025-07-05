using MasterMind.Interface;
using System;

namespace MasterMind.GameCore
{
    /// <summary>
    /// It allows you to write modification commands in the game settings such as:
    /// -Player name 
    /// -Password 
    /// -Number of attempts 
    /// </summary>
    internal class GameCommands : IWritable
    {
        private static GameCommands m_instance;

        /// <summary>
        /// Singelton 
        /// </summary>
        public static GameCommands Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new GameCommands();
                }

                return m_instance;
            }
        }

        public void Write(string input)
        {
            string[] parts = SplitCommand(input);

            if (parts.Length < 2)
            {
                MassagePro.TextPro("You need to enter value",ConsoleColor.Red,10);
                return;
            }

            switch (parts[0])
            {
                case "-p": GameSettings.Instance.ChangePassword(parts[1]);
                    break;
                case "-t": GameSettings.Instance.ChangeAttempts(parts[1]);
                    break;
                case "-n":GameSettings.Instance.ChangePlayerName(input);
                    break;
                case "-rp":GameSettings.Instance.RandomPassword();
                    break;
                case "-r":GameSettings.Instance.ResetGam();
                    break;
                default: MassagePro.TextPro($"Wornig Command : \n{CommandsHelp()}",ConsoleColor.Red,5);
                    break;
            }
        }

        /// <summary>
        /// Used to split and flitering parts of the command
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string[] SplitCommand(string input)
        {
            input = input.Trim();
            return input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Massage the suggested commands for the commands.
        /// </summary>
        /// <returns></returns>
        private string CommandsHelp()
        {
            string massage = "";

            massage += "-t : to update attempts number \n";
            massage += "-p : to update password code \n";
            massage += "-n : to update player`s name \n";

            return massage;
        }
    }
    
}
