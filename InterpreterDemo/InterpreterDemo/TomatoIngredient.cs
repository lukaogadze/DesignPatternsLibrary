namespace InterpreterDemo
{
    public class TomatoIngredient : Ingredient
    {
        public void Interpret(Context context)
        {
            context.Output += " Tomato ";
        }
    }
}