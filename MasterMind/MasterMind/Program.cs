using MasterMind.GameCore;
using System;

namespace MasterMind
{
    /// <summary>
    /// Routes user input to either game commands or gameplay logic,
    /// depending on whether the input starts with a dash (-).
    /// </summary>
    internal class Program
    {
        private static GameCommands commads = new GameCommands();
        private static GameManager gameManager =  GameManager.Instance;

        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                string commandLineInput = string.Join(" ", args);
                IsInputCommand(commandLineInput);
            }

            MassagePro.Text("'MasterMind Game'", ConsoleColor.Yellow , 5);
            MassagePro.Text("Welcome to MasterMind Game", ConsoleColor.White, 5);
            MassagePro.Text("Enter (-start) To Start Game or (-help) to see all options", ConsoleColor.White, 5);

            while (true)
            {
                IsInputCommand(Console.ReadLine());
            }
        }

        private static void IsInputCommand(string input)
        {
            input = input.Trim();

            if(input.StartsWith("-") && gameManager.IsGameStart() == false)
            {
                commads.Write(input);
            }
            else
            {
                gameManager.Write(input);
            }
        }
    }
}
