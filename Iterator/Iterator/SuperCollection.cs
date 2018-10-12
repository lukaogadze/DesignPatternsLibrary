using System.Collections.Generic;

namespace Iterator
{
    public class SuperCollection : List<string>
    {
        public string Get(int index)
        {
            return this[index];
        }
    }
}