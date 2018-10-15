using System.Collections.Generic;
using System.Linq;
using Core.Greed2.Rules;

namespace Core.Greed_2.Rules
{
    public class ThreePairsRule : IRule
    {
        public ScoreResult Eval(int[] dice)
        {
            int pairCount = 0;
            var diceUsed = new List<int>();
            for (int i = 1; i < 7; i++)
            {
                var count = dice.Count(d => d == i);
                if (count % 2 == 0)
                {
                    for (int j = 0; j < count; j++)
                    {
                        diceUsed.Add(i);
                        if(j%2==0)
                        {
                            pairCount++;
                        }
                    }
                }
            }
            if (pairCount == 3)
            {
                return new ScoreResult(diceUsed.ToArray(), 800, this);
            }
            return new ScoreResult();
        }
    }
}