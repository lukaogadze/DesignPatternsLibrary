namespace InterpreterDemo
{
    public class ChickenIngredient : Ingredient
    {
        public void Interpret(Context context)
        {
            context.Output += "Chicken";
        }
    }
}