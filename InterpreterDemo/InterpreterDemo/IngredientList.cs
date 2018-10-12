using System.Collections.Generic;

namespace InterpreterDemo
{
    public class IngredientList : Expression
    {
        private readonly List<Ingredient> _ingredients;

        public IngredientList(List<Ingredient> ingredients)
        {
            _ingredients = ingredients;
        }
        public void Interpret(Context context)
        {
            foreach (var ingredient in _ingredients)
            {
                ingredient.Interpret(context);
            }
        }
    }
}