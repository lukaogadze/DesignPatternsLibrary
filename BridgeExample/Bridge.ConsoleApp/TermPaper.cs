using System;

namespace Bridge.ConsoleApp
{
    public class TermPaper : Manuscript
    {
        public string Class { get; set; }
        public string Student { get; set; }        
        public string Text { get; set; }
        public string Reference { get; set; }

        public override void Print()
        {
            Console.WriteLine(Formatter.Format("Class", Class));
            Console.WriteLine(Formatter.Format("Student", Student));
            Console.WriteLine(Formatter.Format("Text", Text));
            Console.WriteLine(Formatter.Format("Reference", Reference));            
            Console.WriteLine();
        }

        public TermPaper(IFormatter formatter) : base(formatter)
        {
        }
    }
}