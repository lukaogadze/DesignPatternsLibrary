using System;

namespace Automobiles.Autos
{
    public interface IAutomobile
    {
        string Name { get; }
        Guid Id { get; }
        void Start();
        void Stop();
    }
}