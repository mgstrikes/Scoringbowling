using ScroingAndBowlingApp;
using System;
using Xunit;

namespace ScoringAndBowlingApp.Tests
{
    public class GameTests : IDisposable
    {
        private Game game;
        public GameTests()
        {
            game = new Game();
        }

        public void Dispose()
        {
            game = null;
        }

        [Fact]
        public void RollTest_SingleRollPin0_ShouldReturnScore0()
        {
            game.Roll(0);
            var score = game.Score();
            Assert.Equal(0, score);
        }

        [Fact]
        public void RollTest_SingleRollPin20_ShouldReturnScore20()
        {
            game.Roll(20);
            var score = game.Score();
            Assert.Equal(20, score);
        }

        [Fact]
        public void RollTest_20RollsWithPin4_ShouldReturnScore80()
        {
            RollMany(20, 4);
            var score = game.Score();
            Assert.Equal(80, score);

        }

        [Fact]
        public void RollTest_TestSpare()
        {
            RollSpare();
            game.Roll(2);
            RollMany(17, 1);
            var score = game.Score();
            Assert.Equal(31, score);
        }

        [Fact]
        public void RollTest_TestStrike()
        {
            RollStrike();//10+4+5 = 19
            game.Roll(4); // 19+4 = 23
            game.Roll(5); //23+5 = 28
            RollMany(16, 1); //28+16 = 44
            var score = game.Score();
            Assert.Equal(44, score);
        }

        [Fact]
        public void RollTest_ProblemStatement()
        {
            //1 4| 4 5 |6 Spare(4)| 5 Spare(5)| Strike| 0 1|7 Spare(3)| 6 Spare(4)|Strike(10)|2 Spare(8) 6|
            //Total score = 133
            game.Roll(1);
            game.Roll(4);
            game.Roll(4);
            game.Roll(5);
            game.Roll(6);
            game.Roll(4);
            game.Roll(5);
            game.Roll(5);
            RollStrike();
            game.Roll(0);
            game.Roll(1);
            game.Roll(7);
            game.Roll(3);
            game.Roll(6);
            game.Roll(4);
            RollStrike();
            game.Roll(2);
            game.Roll(8);
            game.Roll(6);

            var score = game.Score();
            Assert.Equal(133, score);

        }

        private void RollMany(int turns, int pin)
        {
            for (int i = 0; i < turns; i++)
            {
                game.Roll(pin);
            }
        }

        private void RollSpare()
        {
            game.Roll(4);
            game.Roll(6);
        }

        private void RollStrike()
        {
            game.Roll(10);
        }
    }
}
