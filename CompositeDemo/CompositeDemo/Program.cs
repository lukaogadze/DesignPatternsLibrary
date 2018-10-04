using System;

namespace CompositeDemo
{
    internal static class Program
    {
        private static void Main()
        {
            const int goldForKill = 1023;
            Console.WriteLine("You have killed the Giant IE6 Monster and gained {0} gold!", goldForKill);

            var joe = new Person {Name = "Joe"};
            var jake = new Person {Name = "Jake"};
            var emily = new Person {Name = "Emily"};
            
            var sophia = new Person {Name = "Sophia"};
            var brian = new Person {Name = "Brian"};
            
            var oldBob = new Person {Name = "oldBob"};
            var newBob = new Person {Name = "newBob"};
            
            var bobs = new Group { Members = {oldBob, newBob}};
            
            var developers = new Group {Name = "Developers", Members = {joe, jake, emily, bobs}};

            var parties = new Group
            {
                Members = {developers, sophia, brian}
            };


            parties.Gold += goldForKill;
            parties.Stats();
        }
    }
}