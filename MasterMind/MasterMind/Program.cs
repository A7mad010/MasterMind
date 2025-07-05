using MasterMind.GameCore;
using MasterMind.Interface;
using System;

namespace MasterMind
{
    /// <summary>
    /// Routes user input to either game commands or gameplay logic,
    /// depending on whether the input starts with a dash (-).
    /// </summary>
    internal class Program
    {
        private static IWritable commads = GameCommands.Instance;
        private static IWritable gameManager =  GameManager.Instance;

        static void Main(string[] args)
        {
            MassagePro.TextPro("'MasterMind Game'", ConsoleColor.Yellow , 50);

            while(true)
            {
                IsInputCommand(Console.ReadLine());
            }
        }

        private static void IsInputCommand(string input)
        {
            input = input.Trim();

            if(input.StartsWith("-"))
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
