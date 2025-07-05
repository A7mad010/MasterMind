# MasterMind Game

## Overview  
MasterMind is a console-based game where the player tries to guess a secret numeric password within a limited number of attempts. After each guess, the game gives feedback on how many digits are correctly placed and how many are correct but misplaced.

## Features  
- Supports customizable password and attempts via commands.  
- Validates user input for correct length and numeric characters only.  
- Provides clear feedback each round.  
- Allows starting a new game and tracks game state.

## How to Play  
1. Start the game by typing **yes** when prompted.  
2. Enter your guess as a number matching the password length.  
3. Receive feedback on well-placed and misplaced digits.  
4. Try to guess the password within the allowed attempts.

## Commands  
- `-p [password]` : Set the password.  
- `-t [attempts]` : Set the maximum number of attempts.  
- `-n [playerName]` : Set the player name.

## Requirements  
- .NET (specify version)  
- Console environment  

## How to Run  
Compile and run the program. Follow the prompts in the console to play.
