namespace InterpreterDemo
{
    public class LettuceIngredient : Ingredient
    {
        public void Interpret(Context context)
        {
            context.Output += " Lettuce ";
        }
    }
}