using System.Collections.Generic;
using Core.Greed_2;

namespace Core.Greed2.Rules
{
    public class RuleSet
    {
        private List<IRule> _rules = new List<IRule>();
        public IRule BestRule(int[] dice)
        {
            ScoreResult bestResult = new ScoreResult();
            foreach (var rule in _rules)
            {
                var result = rule.Eval(dice);
                if(result.Score > bestResult.Score)
                {
                    bestResult = result;
                }
            }
            return bestResult.RuleUsed;
        }

        public void Add(IRule rule)
        {
            _rules.Add(rule);
        }
    }
}