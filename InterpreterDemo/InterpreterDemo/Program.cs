using System.Collections.Generic;

namespace InterpreterDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sandwich = new Sandwich(
                new WheatBread(),
                new CondimentList(
                    new List<Condiment>
                    {
                        new MayoCondiment(),
                        new MustardCondiment()
                    }
                ),
                new IngredientList(
                    new List<Ingredient>
                    {
                        new LettuceIngredient(),
                        new ChickenIngredient()
                    }
                ),
                new CondimentList(
                    new List<Condiment>
                    {
                        new KetchupCondiment()
                    }
                ),
                new WheatBread()
            );
            
            sandwich.Interpret(new Context());
        }
    }
}