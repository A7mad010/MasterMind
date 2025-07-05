using MasterMind.Interface;
using System;
using System.Linq;

namespace MasterMind.GameCore
{
    /// <summary>
    /// Manages the main gameplay loop for the MasterMind game,
    /// including input validation, guess processing, and game state tracking.
    /// </summary>
    internal class GameManager : IWritable
    {
        private int m_round = 0;
        private bool m_isGameStarted = false;
        private bool m_isGameOver = false;

        private static GameManager m_instance;

        /// <summary>
        /// Singelton 
        /// </summary>
        public static GameManager Instance
        {
            get
            {
                if(m_instance == null)
                {
                    m_instance = new GameManager();
                }

                return m_instance;
            }
        }

        /// <summary>
        /// Processes the given input string.
        /// </summary>
        /// <param name="input">The input string to be processed.</param>
        public void Write(string input)
        {
            if (m_isGameOver)
            {
                MassagePro.TextPro("Game over. Start a new game or reset the password.", ConsoleColor.Red, 10);
                return;
            }

            if (!m_isGameStarted)
            {
                HandleGameStart(input);
                return;
            }

            if (!IsValidGuess(input))
            {
                MassagePro.TextPro("Invalid input. Please enter a 4-digit number.", ConsoleColor.Red, 5);
                return;
            }

            ProcessGuess(input);
        }

        public void ReStartGame()
        {
            m_isGameOver = false;
            m_isGameStarted = false;
            m_round = 0;
        }

        /// <summary>
        /// Handles the initial game start input from the user.
        /// Starts the game if the user inputs 'yes',
        /// otherwise prompts the user to confirm if they are ready.
        /// </summary>
        /// <param name="input"></param>
        private void HandleGameStart(string input)
        {
            if (input.Trim().ToLower() == "yes")
            {
                if(GameSettings.Instance.passwordCode == "")
                {
                    GameSettings.Instance.RandomPassword();
                }

                m_isGameStarted = true;
                m_round = 1;
                MassagePro.TextPro("Game started! Try to guess the password.", ConsoleColor.Green, 5);
            }
            else
            {
                MassagePro.TextPro("Are you ready to start? [yes/no]", ConsoleColor.Yellow, 5);
            }
        }

        /// <summary>
        /// Check if your answer has no letters or a number of digits more or less than required.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool IsValidGuess(string input)
        {
            return InputValidator.Instance.IsNumericOnly(input) && InputValidator.Instance.IsCorrectLenght(input,GameSettings.Instance.passwordCode.Length);
        }

        /// <summary>
        /// Used to print the result of the round.
        /// </summary>
        /// <param name="input"></param>
        private void ProcessGuess(string input)
        {
            string password = GameSettings.Instance.passwordCode;
            int well = GetWellPlacedCount(input);
            int mis = GetMisPlacedCount(input);

            MassagePro.TextPro($"Round: {m_round}", threadSleep: 5);
            MassagePro.TextPro($"Well placed pieces : {well}", threadSleep: 5);
            MassagePro.TextPro($"Misplaced pieces  : {mis}", threadSleep: 5);
            MassagePro.TextPro("=========================");

            if (well == password.Length)
            {
                MassagePro.TextPro("🎉 You won! Password is correct.", ConsoleColor.Green, 30);
                m_isGameOver = true;
                return;
            }

            m_round++;

            if (m_round > GameSettings.Instance.attempts)
            {
                MassagePro.TextPro($"💥 Game over. The correct password was: {password}", ConsoleColor.Red, 30);
                m_isGameOver = true;
            }
        }

        /// <summary>
        /// Returns an integer value for the number of correct digits in the correct place.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int GetWellPlacedCount(string input)
        {
            int count = 0;
            string password = GameSettings.Instance.passwordCode;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == password[i])
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// It returns an integer value for the number of digits in the wrong place.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int GetMisPlacedCount(string input)
        {
            int count = 0;
            string password = GameSettings.Instance.passwordCode;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != password[i] && password.Contains(input[i]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}