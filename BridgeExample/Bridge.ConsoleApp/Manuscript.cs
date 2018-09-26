
namespace Bridge.ConsoleApp
{
    public abstract class Manuscript
    {
        public IFormatter Formatter { get; private set; }

        public Manuscript(IFormatter formatter)
        {
            Formatter = formatter;
        }
        public abstract void Print();
    }
}