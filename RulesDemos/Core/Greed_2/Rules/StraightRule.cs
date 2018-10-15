using System.Linq;
using Core.Greed2.Rules;

namespace Core.Greed_2.Rules
{
    public class StraightRule : IRule
    {
        public ScoreResult Eval(int[] dice)
        {
            for (int i = 1; i < 7; i++)
            {
                if (!dice.Contains(i))
                {
                    return new ScoreResult();
                }
            }
            var diceUsed = new int[] { 1, 2, 3, 4, 5, 6 };
            return new ScoreResult(diceUsed, 1200, this);
        }
    }
}