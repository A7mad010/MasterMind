using System;
using System.Threading;

namespace MasterMind.GameCore
{
    /// <summary>
    /// You can easily control the text formatting.
    /// </summary>
    internal static class MassagePro
    {

        /// <summary>
        /// You can easily control the text formatting.
        /// </summary>
        public static void Text(string text = "", ConsoleColor color = ConsoleColor.White, int threadSleep = 0)
        {
            Console.ForegroundColor = color;
            
            foreach(char ch in text)
            {
                Console.Write(ch);
                Thread.Sleep(threadSleep);
            }
            Console.WriteLine();

            Console.ResetColor();
        }
    }
}
