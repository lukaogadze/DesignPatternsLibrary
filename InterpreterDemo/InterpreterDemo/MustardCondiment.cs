namespace InterpreterDemo
{
    public class MustardCondiment : Condiment
    {
        public void Interpret(Context context)
        {
            context.Output += " Mustard ";
        }
    }
}