using System.Collections.Generic;

namespace InterpreterDemo
{
    public class CondimentList : Expression
    {
        private readonly List<Condiment> _condiments;

        public CondimentList(List<Condiment> condiments)
        {
            _condiments = condiments;
        }
        public void Interpret(Context context)
        {
            foreach (var condiment in _condiments)
            {
                condiment.Interpret(context);
            }
        }
    }
}