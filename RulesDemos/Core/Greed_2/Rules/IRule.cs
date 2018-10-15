using Core.Greed_2;

namespace Core.Greed2.Rules
{
    public interface IRule
    {
        ScoreResult Eval(int[] dice);
    }
}