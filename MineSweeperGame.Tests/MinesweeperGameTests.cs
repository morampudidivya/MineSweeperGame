using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinesweeperGames;
using NUnit.Framework;

namespace game.Test
{


    [TestFixture]
    public class MinesweeperGameTests
    {
        private MinesweeperGame _game;

        [SetUp]
        public void SetUp()
        {
            _game = new MinesweeperGame(size: 5, mines: 2, lives: 3);
        }

        [Test]
        public void InitialConditions_AreCorrect()
        {
            Assert.AreEqual(3, _game.Lives);
            Assert.AreEqual("A1", _game.CurrentPosition);
            Assert.AreEqual(0, _game.MovesTaken);
        }

        [Test]
        public void Move_Right_ChangesPosition()
        {
            _game.Move("right");
            Assert.AreEqual("B1", _game.CurrentPosition);
            Assert.AreEqual(1, _game.MovesTaken);
        }

        [Test]
        public void Move_Invalid_DoesNotChangePosition()
        {
            _game.Move("invalid");
            Assert.AreEqual("A1", _game.CurrentPosition);
            Assert.AreEqual(0, _game.MovesTaken);
        }

        [Test]
        public void HittingMine_ReducesLives()
        {
            // hitting a mine by placing one manually for testing
            _game = new MinesweeperGame(size: 1, mines: 1, lives: 3);
            _game.Move("down");  // Move to mine position
            Assert.Less(_game.Lives, 3);
        }

        [Test]
        public void ReachingLastRow_EndsGame()
        {
            for (int i = 0; i < 4; i++) _game.Move("down");
            Assert.True(_game.IsGameOver);
        }
    }

}
