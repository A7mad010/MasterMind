using MasterMind.GameCore;
using System;

namespace MasterMind
{
    internal class Program
    {
        static GameCommands commads = new GameCommands();

        static void Main(string[] args)
        {
            GameSettings.Instance.RandomPassword();
            Console.WriteLine(GameSettings.Instance.password );

            Console.WriteLine("--------------------");
            IsInputCommand(Console.ReadLine());
        }

        static void IsInputCommand(string input)
        {
            input = input.Trim();

            if(input.StartsWith("-"))
            {
                commads.Write(input);
            }
            else
            {
                Console.WriteLine("It is answor");
            }
        }
    }
}
