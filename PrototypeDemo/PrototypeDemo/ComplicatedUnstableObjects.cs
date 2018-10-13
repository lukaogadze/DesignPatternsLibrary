using System;

namespace PrototypeDemo
{
    public class ComplicatedUnstableObjects : ICloneable
    {
        internal ComplicatedUnstableObjects(string a, int b, int c, char d, string e)
        {
            
        }

        internal ComplicatedUnstableObjects(int ba, int c, char d, string e)
        {
            
        }

        internal ComplicatedUnstableObjects(string a, char da, string e)
        {
            
        }

        internal ComplicatedUnstableObjects(string a, int c, char d, string e, string f)
        {
            
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}