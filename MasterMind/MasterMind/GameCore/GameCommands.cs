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
                case "-password": GameSettings.Instance.ChangePassword(parts[1]);
                    break;
                case "-attempt": GameSettings.Instance.ChangeAttempts(parts[1]);
                    break;
                case "-start": GameManager.Instance.HandleGameStart();
                    break;
                case "-restart": GameManager.Instance.ReStartGame();
                    break;
                case "-random": GameSettings.Instance.RandomPassword();
                    break;
                case "-exit": Environment.Exit(0);
                    break;
                case "-help": MassagePro.Text($"All commands in the game : \n{CommandsHelp()}",ConsoleColor.Yellow,5);
                    break;
                default: MassagePro.Text($"Worng Command : \n{CommandsHelp()}",ConsoleColor.Red,5);
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

            massage += "-start : to start game \n";
            massage += "-restart : to reStart game \n";
            massage += "-attempt : to update attempts number \n";
            massage += "-password : to update password code \n";
            massage += "-random : To set a random password \n";
            massage += "-exit : to exit game \n";
            massage += "-help : to show all the commands \n";

            return massage;
        }
    }
    
}
