namespace InterpreterDemo
{
    public class KetchupCondiment : Condiment
    {
        public void Interpret(Context context)
        {
            context.Output += " Ketchup ";
        }
    }
}