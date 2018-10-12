namespace InterpreterDemo
{
    public interface Bread : Expression
    {
    }
    
    public class WhiteBread : Bread
    {
        public void Interpret(Context context)
        {
            context.Output += " White-Bread ";
        }
    }
    
    public class WheatBread : Bread
    {
        public void Interpret(Context context)
        {
            context.Output += " Wheat-Bread ";
        }
    }
}