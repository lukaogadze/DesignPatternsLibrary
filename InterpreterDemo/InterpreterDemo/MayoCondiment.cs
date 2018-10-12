namespace InterpreterDemo
{
    public class MayoCondiment : Condiment
    {
        public void Interpret(Context context)
        {
            context.Output += " Mayo ";
        }
    }
}