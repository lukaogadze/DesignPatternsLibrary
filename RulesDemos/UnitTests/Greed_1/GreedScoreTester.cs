using Core.Greed_1;
using NUnit.Framework;

namespace UnitTests.Greed_1
{
    [TestFixture]
    public class GreedScoreTester
    {
        private Greed _greedGame;

        [SetUp]
        public void MyTestInitialize()
        {
            _greedGame = new Greed();
        }

        [Test]
        public void NoSetsResultsInZeroScore()
        {
            int score = _greedGame.Score(new int[] {2, 3, 4, 3, 2});
            Assert.AreEqual(0, score);
        }

        [Test]
        public void OneIsWorth100()
        {
            int score = _greedGame.Score(new int[1] {1});
            Assert.AreEqual(100, score);
        }

        [Test]
        public void TwoOnesAreWorth200()
        {
            int score = _greedGame.Score(new int[] {1, 1});
            Assert.AreEqual(200, score);
        }

        [Test]
        public void ThreeOnesAreWorth1000()
        {
            int score = _greedGame.Score(new int[] {1, 1, 1});
            Assert.AreEqual(1000, score);
        }

        [Test]
        public void FourOnesAreWorth1100()
        {
            int score = _greedGame.Score(new[] {1, 1, 1, 1});
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
            int score = _greedGame.Score(new[] { 5,5,5 });
            Assert.AreEqual(500, score);
        }

        [Test]
        public void ThreeTwosAreWorth200()
        {
            int score = _greedGame.Score(new[] { 2,2,2 });
            Assert.AreEqual(200, score);
        }

        [Test]
        public void GivenAssertionsAreCorrect()
        {
            Assert.AreEqual(1150, _greedGame.Score(new[] {1, 1, 1, 5, 1}));
            Assert.AreEqual(0, _greedGame.Score(new[] {2, 3, 4, 6, 2}));
            Assert.AreEqual(350, _greedGame.Score(new[] {3,4,5,3,3}));
            Assert.AreEqual(250, _greedGame.Score(new[] {1, 5, 1, 2, 4}));

        }
    }
}