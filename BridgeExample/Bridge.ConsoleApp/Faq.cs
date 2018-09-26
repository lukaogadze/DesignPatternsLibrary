using System.Collections.Generic;
using static System.Console;

namespace Bridge.ConsoleApp
{
    public class Faq : Manuscript
    {
        public string Title { get; set; }
        public Dictionary<string,string> Questions { get; set; }

        public Faq(IFormatter formatter) : base(formatter)
        {
            Questions = new Dictionary<string, string>();
        }

        public override void Print()
        {
            WriteLine(Formatter.Format("Title", Title));
            foreach (var question in Questions)
            {
                WriteLine(Formatter.Format("    Question", question.Key));
                WriteLine(Formatter.Format("    Answer", question.Value));
            }
            WriteLine();
        }
    }
}