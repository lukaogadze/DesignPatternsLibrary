using System.Collections.Generic;

namespace Bridge.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var document = new List<Manuscript>();
            var formatter = new FancyFormatter();
            
            var faq = new Faq(formatter);
            faq.Title = "The Bridge Pattern FAQ";
            faq.Questions.Add("What is it?", "A design pattern");
            faq.Questions.Add("When do we use it?", "When you need to separate an abstraction from an implementation");
            document.Add(faq);

            
            var book = new Book(formatter)
            {
                Title = "Lots of Patterns",
                Author = "John Sonmez",
                Text = "Blah blah blah..."
            };
            document.Add(book);

            var paper = new TermPaper(formatter)
            {
                Class = "Design Patterns",
                Student = "Joe N00b",
                Text = "Blah blah blah...",
                Reference = "GOF"
            };
            document.Add(paper);

            foreach (var manuscript in document)
            {
                manuscript.Print();
            }
        }
    }
}