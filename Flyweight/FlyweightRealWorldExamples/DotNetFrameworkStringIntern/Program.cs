using System;

namespace DotNetFrameworkStringIntern
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "flyweight";

            string s2 = "flyweight";

            //string s2 = s1;
            
            //string s2 = string.Intern(Console.ReadLine()); 
            
            Console.WriteLine(ReferenceEquals(s1, s2));            
        }       
    }
}
