using Microsoft.VisualBasic;
using System;
using System.Numerics;

namespace game
{
    public class MinesweeperGame
    {
        private readonly int _size;
        private readonly HashSet<(int, int)> _mines;
        private int _lives;
        private (int, int) _position;
        private int _movesTaken;

        public MinesweeperGame(int size, int mines, int lives)
        {
            _size = size;
            _mines = PlaceMines(mines);
            _lives = lives;
            _position = (0, 0); // Starting position: A1 (0,0)
            _movesTaken = 0;
        }

        private HashSet<(int, int)> PlaceMines(int count)
        {
            Random rand = new Random();
            var mines = new HashSet<(int, int)>();
            while (mines.Count < count)
            {
                var minePosition = (rand.Next(0, _size), rand.Next(0, _size));
                if (minePosition != (0, 0)) mines.Add(minePosition);
            }
            return mines;
        }

        public void Move(string direction)
        {
            var newPosition = GetNewPosition(direction);
            if (newPosition == _position || _lives <= 0) return;

            _movesTaken++;
            _position = newPosition;

            if (_mines.Contains(_position))
            {
                _lives--;
                _mines.Remove(_position);  // Mine removed after hit
            }
        }

        private (int, int) GetNewPosition(string direction)
        {
            var (x, y) = _position;
            return direction.ToLower() switch
            {
                "up" => (Math.Max(0, x - 1), y),
                "down" => (Math.Min(_size - 1, x + 1), y),
                "left" => (x, Math.Max(0, y - 1)),
                "right" => (x, Math.Min(_size - 1, y + 1)),
                _ => _position
            };
        }

        public bool IsGameOver => _position.Item1 == _size - 1 || _lives <= 0;

        public string CurrentPosition => $"{(char)(_position.Item2 + 65)}{_position.Item1 + 1}";
        public int Lives => _lives;
        public int MovesTaken => _movesTaken;
    }
   
}
