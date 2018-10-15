using System.Collections.Generic;
using System.Linq;
using Core.Greed2.Rules;

namespace Core.Greed_2.Rules
{
    public class SetOfDiceRule : IRule
    {
        private readonly int _setSize;
        private readonly int _dieValue;
        private readonly int _score;

        public SetOfDiceRule(int setSize, int dieValue, int score)
        {
            _setSize = setSize;
            _dieValue = dieValue;
            _score = score;
        }

        public ScoreResult Eval(int[] dice)
        {
            var result = new ScoreResult();
            if (dice.Count(d => d == _dieValue) >= _setSize)
            {
                List<int> diceUsed = new List<int>();
                while (diceUsed.Count < _setSize)
                {
                    diceUsed.Add(_dieValue);
                }
                result.DiceUsed = diceUsed.ToArray();
                
                result.Score = _score;
                result.RuleUsed = this;
            }
            return result;
        }

    }

    public class TripleDieRule : IRule
    {
        private readonly SetOfDiceRule _setOfDiceRule;

        public TripleDieRule(int dieValue, int score)
        {
            _setOfDiceRule = new SetOfDiceRule(3, dieValue, score);
        }

        public ScoreResult Eval(int[] dice)
        {
            return _setOfDiceRule.Eval(dice);
        }
    }

    public class FourOfADieRule : IRule
    {
        private readonly SetOfDiceRule _setOfDiceRule;

        public FourOfADieRule(int dieValue, int score)
        {
            _setOfDiceRule = new SetOfDiceRule(4, dieValue, score);
        }

        public ScoreResult Eval(int[] dice)
        {
            return _setOfDiceRule.Eval(dice);
        }
    }
}