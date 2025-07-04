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
        public void Write(string input)
        {
            string[] parts = SplitCommand(input);

            switch (parts[0])
            {
                case "-p": GameSettings.Instance.ChangePassword(parts[1]);
                    break;
                case "-t": GameSettings.Instance.ChangeAttempts(parts[1]);
                    break;
                case "-n":GameSettings.Instance.ChangePlayerName(input);
                    break;
                default: Console.WriteLine("Wornig Command");
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
    }
    
}
