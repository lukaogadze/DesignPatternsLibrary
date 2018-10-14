using System.Collections.Generic;

namespace FileLoggerSample
{
    public class NumberGenerator
    {
        public IEnumerable<long> Integers()
        {
            long currentValue = 1;
            while (true)
            {
                yield return currentValue++;
            }
        }
    }
}