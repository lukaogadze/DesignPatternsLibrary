using System;
using System.Linq;
using Core.Greed_2;

namespace Core.Greed2.Rules
{
    public class OnesScoreRule : IRule
    {
        public ScoreResult Eval(int[] dice)
        {
            return new SingleDieRule(1, 1000).Eval(dice);
        }
    }

    public class FivesScoreRule : IRule
    {
        public ScoreResult Eval(int[] dice)
        {
            return new SingleDieRule(5, 50).Eval(dice);
        }
    }

    public class SingleDieRule : IRule
    {
        private readonly int _dieValue;
        private readonly int _score;

        public SingleDieRule(int dieValue, int score)
        {
            _dieValue = dieValue;
            _score = score;
        }

        public ScoreResult Eval(int[] dice)
        {
            var result = new ScoreResult();
            result.DiceUsed = dice.Where(d => d == _dieValue).ToArray();
            result.Score = result.DiceUsed.Count() * _score;
            result.RuleUsed = this;
            return result;
        }
    }
}