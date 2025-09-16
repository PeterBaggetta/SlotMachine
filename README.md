# SlotMachine

A fun, interactive C# console game that simulates a **slot machine** — wager on lines, spin the reels, and see if you win!  

---

## Features

- **Multiple Game Modes**  
  Choose from several wagering options:  
  1. **Center Horizontal Line** – Bet on the middle row  
  2. **Center Vertical Line** – Bet on the middle column  
  3. **All Three Horizontal Lines** – Bet on every row  
  4. **All Three Vertical Lines** – Bet on every column  
  5. **Both Diagonals** – Bet on the two diagonals  
  6. **All Lines** – Bet on every possible line at once  

- **Money Balance Tracking**  
  The game keeps track of your money and deducts the correct amount for each wager.

- **Randomized Reel Spins**  
  Each spin generates a fresh 3×3 grid of random numbers.

- **Win Detection**  
  Checks rows, columns, and diagonals based on your wager choice to determine wins.

- **Replay Option**  
  Continue spinning until you run out of money — or quit anytime.

---

## How It Works

1. **Input Stage**  
   - Prompts the user for a starting balance  
   - Ensures the amount is greater than zero  

2. **Game Mode Selection**  
   - Displays a menu of wagering options and their costs  
   - Validates the user’s choice  

3. **Spin and Result**  
   - Generates a 3×3 slot machine board with random numbers  
   - Checks the chosen lines for matches  
   - Displays number of wins and updates balance accordingly  

4. **Repeat or Quit**  
   - Allows the player to keep playing as long as they have funds  
   - Ends the game gracefully when the player quits or runs out of money  

---

## Purpose

This project is designed to:
- Practice **2D arrays** and traversal 2D arrays  
- Checking for different win conditions within a 2D array 
- Keeping track of a running balance  

---

## Example Gameplay

### Introduction
```
Welcome to the Slot Machine!! Wager your money on a line! If you wager correctly, YOU WIN!
What is your starting balance: $
```

### Main Game Window
```
Your balance: $50

Choose which lines you would like to play ($1 per line):
        0. QUIT
        1. Center horizontal line       (cost $1)
        2. Center vertical line         (cost $1)
        3. All three horizontal lines   (cost $3)
        4. All three vertical lines     (cost $3)
        5. Both diagonals               (cost $2)
        6. All Lines                    (cost $8)
Choose an option:
```
### Losing Example
```
6

1 0 1
0 0 1
1 1 2

You did not win on any line.

Want to spin again? (Y/N):
```

### Winning Example
```
4

1 2 1
1 2 2
0 2 2

You won 1 time(s)!

Want to spin again? (Y/N):
```
