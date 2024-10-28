using game;
using System;

class Program
{
    static void Main()
    {
        var game = new MinesweeperGame(size: 8, mines: 10, lives: 3);
        Console.WriteLine("Welcome to Minesweeper! Navigate with 'up', 'down', 'left', 'right'.");

        while (!game.IsGameOver)
        {
            Console.Write($"Current position: {game.CurrentPosition}, Lives: {game.Lives}, Moves: {game.MovesTaken}\nMove: ");
            var input = Console.ReadLine();
            game.Move(input);

            if (game.Lives <= 0) Console.WriteLine("Game Over! You hit too many mines.");
            else if (game.IsGameOver) Console.WriteLine("You made it to the other side!");
        }

        Console.WriteLine($"Total moves: {game.MovesTaken}");
    }
}
