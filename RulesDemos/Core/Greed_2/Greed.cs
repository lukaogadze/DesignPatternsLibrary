using System;
using System.Collections.Generic;
using System.Linq;
using Core.Greed2.Rules;
using Core.Greed_2.Rules;

namespace Core.Greed_2
{
    public class Greed
    {
        private readonly RuleSet _ruleSet = new RuleSet();

        public Greed()
            : this(true)
        {
        }
        public Greed(bool useAllRules)
        {
            _ruleSet.Add(new SingleDieRule(1, 100));
            _ruleSet.Add(new SingleDieRule(5, 50));
            _ruleSet.Add(new TripleDieRule(1, 1000));
            if (useAllRules)
            {
                _ruleSet.Add(new FourOfADieRule(1, 2000));
                _ruleSet.Add(new SetOfDiceRule(5, 1, 4000));
                _ruleSet.Add(new SetOfDiceRule(6, 1, 8000));
                _ruleSet.Add(new StraightRule());
                _ruleSet.Add(new ThreePairsRule());
            }
            for (int i = 2; i < 7; i++)
            {
                _ruleSet.Add(new TripleDieRule(i, i * 100));
                if (useAllRules)
                {
                    _ruleSet.Add(new FourOfADieRule(i, i*200));
                    _ruleSet.Add(new SetOfDiceRule(5, i, i*400));
                    _ruleSet.Add(new SetOfDiceRule(6, i, i*800));
                }
            }
        }

        public void AddScoringRule(IRule rule)
        {
            _ruleSet.Add(rule);
        }

        public int Score(int[] roles)
        {
            int score = 0;
            var remainingDice = new List<int>(roles);
            var bestRule = _ruleSet.BestRule(remainingDice.ToArray());
            while(bestRule != null)
            {
                var result = bestRule.Eval(remainingDice.ToArray());
                foreach (var die in result.DiceUsed)
                {
                    remainingDice.Remove(die);
                }
                score += result.Score;
                bestRule = _ruleSet.BestRule(remainingDice.ToArray());
            }
            return score;
        }
    }
}