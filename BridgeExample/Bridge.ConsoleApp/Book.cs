using static System.Console;

namespace Bridge.ConsoleApp
{
    public class Book : Manuscript
    {
        public Book(IFormatter formatter) : base(formatter)
        {
        }
        
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }

        public override void Print()
        {            
            WriteLine(Formatter.Format("Title", Title));
            WriteLine(Formatter.Format("Author", Author));
            WriteLine(Formatter.Format("Text", Text));
            WriteLine();
        }       
    }
}