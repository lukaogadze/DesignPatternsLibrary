using System.Collections.Generic;

namespace VisitorDemo
{
    public class Person : IAsset
    {
        public readonly List<IAsset> Assets;

        public Person(List<IAsset> assets)
        {
            Assets = assets;
        }

        public Person(): this(new List<IAsset>())
        {
            
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var asset in Assets)
            {
                asset.Accept(visitor);
            }
        }
    }
}