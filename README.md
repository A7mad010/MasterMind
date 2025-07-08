# MasterMind Game

A console-based MasterMind game written in C#.

---

## Game Description

Guess a secret 4-digit password with unique digits.  
After each guess, you get feedback on how many digits are correct and in the right place,  
and how many digits are correct but in the wrong place.

---

## How to Run

You have two options to run the MasterMind game:

1. **Run via Visual Studio**  
   - Open the project in Visual Studio.  
   - Press **Start (F5)** to build and run the game.

2. **Run via Shortcut**  
   - Open the folder `MasterMind\MasterMind` in your file explorer.  
   - Double-click the shortcut named **"mastermind Game"** to launch the game executable directly without opening Visual Studio.

---

## Game Commands

| Command       | Description                              |
|---------------|------------------------------------------|
| `-start`      | Start the game                          |
| `-password`   | Change the secret password (4 unique digits) |
| `-attempt`    | Change the number of allowed attempts   |
| `-random`     | Generate a random secret password        |
| `-restart`    | Restart the game                        |
| `-help`       | Show all commands                       |
| `-exit`       | Exit the game                          |

---

## How to Play

- After starting the game, enter your 4-digit guess.  
- You will receive feedback on the number of digits correctly placed and misplaced.  
- Keep guessing until you find the secret password or run out of attempts.

---

## Project Structure

- `Program.cs`: Entry point that routes user input.  
- `GameCommands.cs`: Handles game commands.  
- `GameManager.cs`: Core gameplay logic.  
- `GameSettings.cs`: Stores game settings like password and attempts.  
- `InputValidator.cs`: Validates user input.  
- `MassagePro.cs`: Prints colorful and animated text to the console.  
- `IWritable.cs`: Interface for classes that process input.

---

## System Requirements

- Compatible .NET Framework or .NET Core version.  
- Visual Studio or any C# IDE.

---

## Tips

- Use `-help` command inside the game to see all available commands.  
- Have fun cracking the code!
