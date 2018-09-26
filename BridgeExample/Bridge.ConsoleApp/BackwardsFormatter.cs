using System;
using System.Linq;

namespace Bridge.ConsoleApp
{
    public class BackwardsFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return $"{key}: {new string(value.Reverse().ToArray())}";
        }
    }
}