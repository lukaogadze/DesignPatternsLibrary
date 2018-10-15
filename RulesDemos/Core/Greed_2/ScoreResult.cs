using Core.Greed2.Rules;

namespace Core.Greed_2
{
    public class ScoreResult
    {
        public ScoreResult()
        {
            
        }

        public ScoreResult(int[] diceUsed, int score, IRule ruleUsed)
        {
            DiceUsed = diceUsed;
            Score = score;
            RuleUsed = ruleUsed;
        }
        public int[] DiceUsed;
        public int Score;
        public IRule RuleUsed;
    }
}