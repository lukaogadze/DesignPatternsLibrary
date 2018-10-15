using System;
using Core.Greed2.Rules;
using Core.Greed_2;
using Core.Greed_2.Rules;
using NUnit.Framework;

namespace UnitTests.Greed_2
{
    [TestFixture]
    public class GreedScoreTester
    {
        private Greed _greedGame;

        [SetUp]
        public void SetUp()
        {
            _greedGame = new Greed();
        }

        [Test]
        public void NoSetsResultsInZeroScore()
        {
            int score = _greedGame.Score(new int[] { 2, 3, 4, 3, 2 });
            Assert.AreEqual(0, score);
        }

        [Test]
        public void OneIsWorth100()
        {
            int score = _greedGame.Score(new int[1] { 1 });
            Assert.AreEqual(100, score);
        }

        [Test]
        public void TwoOnesAreWorth200()
        {
            int score = _greedGame.Score(new int[] { 1, 1 });
            Assert.AreEqual(200, score);
        }

        [Test]
        public void ThreeOnesAreWorth1000()
        {
            int score = _greedGame.Score(new int[] { 1, 1, 1 });
            Assert.AreEqual(1000, score);
        }

        [Test]
        public void FourOnesAreWorth1100()
        {
            var game = new Greed(false);
            int score = game.Score(new[] { 1, 1, 1, 1 });
            Assert.AreEqual(1100, score);
        }

        [Test]
        public void OneFiveIsWorth50()
        {
            int score = _greedGame.Score(new[] { 5 });
            Assert.AreEqual(50, score);
        }

        [Test]
        public void ThreeFivesAreWorth500()
        {
            int score = _greedGame.Score(new[] { 5, 5, 5 });
            Assert.AreEqual(500, score);
        }

        [Test]
        public void ThreeTwosAreWorth200()
        {
            int score = _greedGame.Score(new[] { 2, 2, 2 });
            Assert.AreEqual(200, score);
        }

        [Test]
        public void GivenAssertionsAreCorrect()
        {
            var game = new Greed(false);
            Assert.AreEqual(1150, game.Score(new[] { 1, 1, 1, 5, 1 }));
            Assert.AreEqual(0, game.Score(new[] { 2, 3, 4, 6, 2 }));
            Assert.AreEqual(350, game.Score(new[] { 3, 4, 5, 3, 3 }));
            Assert.AreEqual(250, game.Score(new[] { 1, 5, 1, 2, 4 }));

        }

        [Test]
        public void ScoreResultForOneIs100()
        {
            var rule = new SingleDieRule(1, 100);
            var result = rule.Eval(new[] { 1 });

            Assert.AreEqual(1, result.DiceUsed.Length);
            Assert.AreEqual(1, result.DiceUsed[0]);
            Assert.AreEqual(100, result.Score);
        }

        [Test]
        public void ScoreResultForTwoOnesIs200()
        {
            var rule = new SingleDieRule(1, 100);
            var result = rule.Eval(new[] { 1, 1 });

            Assert.AreEqual(2, result.DiceUsed.Length);
            Assert.AreEqual(1, result.DiceUsed[0]);
            Assert.AreEqual(1, result.DiceUsed[1]);
            Assert.AreEqual(200, result.Score);
        }

        [Test]
        public void ShouldScore2000With4Ones()
        {
            Assert.AreEqual(2000, _greedGame.Score(new[] { 1, 1, 1, 1, 4, 6 }));
        }
        [Test]
        public void ShouldScore8000With6Ones()
        {
            Assert.AreEqual(8000, _greedGame.Score(new[] { 1, 1, 1, 1, 1, 1 }));
        }
        [Test]
        public void ShouldScore1200WithStraight()
        {
            Assert.AreEqual(1200, _greedGame.Score(new[] { 1, 2, 3, 4, 5, 6 }));
        }

        [Test]
        public void ShouldScore800With3Pairs()
        {
            Assert.AreEqual(800, _greedGame.Score(new[] { 1, 1, 2, 2, 6, 6 }));
        }

        [Test]
        public void ShouldScore800With3PairsAnd6TwosBasicRulesAnd3PairsRuleOnly()
        {
            var game = new Greed(false);
            game.AddScoringRule(new ThreePairsRule());
            Assert.AreEqual(800, game.Score(new[] { 2,2,2,2,2,2 }));
        }

    }
}