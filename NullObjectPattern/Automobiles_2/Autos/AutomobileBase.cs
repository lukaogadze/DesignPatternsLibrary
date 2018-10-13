using System;

namespace Automobiles.Autos
{
    public abstract class AutomobileBase
    {
        public abstract Guid Id { get; }
        public abstract string Name { get; }
        public abstract void Start();
        public abstract void Stop();

        #region NULL

        private static readonly NullAutomobile _nullAutomobile = new NullAutomobile();

        public static NullAutomobile NULL => _nullAutomobile;

        public class NullAutomobile : AutomobileBase
        {
            public override Guid Id
            {
                get { return Guid.Empty; }
            }

            public override string Name
            {
                get { return string.Empty; }
            }

            public override void Start() { }
            public override void Stop() { }
        }
        
        #endregion
    }
}