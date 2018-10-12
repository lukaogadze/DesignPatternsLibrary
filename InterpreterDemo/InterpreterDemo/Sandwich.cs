using System;

namespace InterpreterDemo
{
    
    // BNF:
    // <sandwich> ::= <bread> <condimentList> <ingredientList> <condimentList> <bread>
    // <condimentList> ::= { <condiment> }
    // <ingredientList> ::= { <ingredient> }
    // <bread> ::= <whiteBread> | <wheatBread>
    // <condiment> ::= <mayoCondiment> | <mustardCondiment> | <ketchupCondiment>
    // <ingredient> ::= <lettuceIngredient> | <tomatoIngredient> | <chickenIngredient> 
    
    public class Sandwich : Expression
    {
        private readonly Bread _topBread;
        private readonly CondimentList _topCondiment;
        private readonly IngredientList _ingredients;
        private readonly CondimentList _bottomCondiments;
        private readonly Bread _bottomBread;

        public Sandwich(Bread topBread, CondimentList topCondiment, IngredientList ingredients, CondimentList bottomCondiments, Bread bottomBread)
        {
            _topBread = topBread;
            _topCondiment = topCondiment;
            _ingredients = ingredients;
            _bottomCondiments = bottomCondiments;
            _bottomBread = bottomBread;
        }

        public void Interpret(Context context)
        {
            context.Output += "|";
            _topBread.Interpret(context);
            context.Output += "|";
            context.Output += "<--";
            _topCondiment.Interpret(context);
            context.Output += "-";
            _ingredients.Interpret(context);
            context.Output += "-";
            _bottomCondiments.Interpret(context);
            context.Output += "-->";
            context.Output += "|";
            _bottomBread.Interpret(context);
            context.Output += "|";
            Console.WriteLine(context.Output);
        }
    }
}