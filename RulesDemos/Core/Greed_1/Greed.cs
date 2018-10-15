using System;
using System.Linq;

namespace Core.Greed_1
{
    public class Greed
    {
        public int Score(int[] roles)
        {
            int score = 0;
            for(int i = 1; i < 7; i++)
            {
                int count = CountDiceWithValue(roles, i);
                count = ScoreSetOfN(count, GetSetSize(i), GetSetScore(i), ref score);
                score += count*GetSingleDieScore(i);
            }
            return score;
        }

        private int GetSingleDieScore(int val)
        {
            if (val == 1) return 100;
            if (val == 5) return 50;
            return 0;
        }

        private int GetSetScore(int val)
        {
            if (val == 1) return 1000;
            return val*100;
        }

        private int GetSetSize(int val)
        {
            return 3;
        }

        private int ScoreSetOfN(int count, int setSize, int setScore, ref int score)
        {
            if (count >= setSize)
            {
                score += setScore;
                return count - 3;
            }
            return count;
        }

        private int CountDiceWithValue(int[] roles, int val)
        {
            return roles.Count(r => r == val);
        }
    }
}