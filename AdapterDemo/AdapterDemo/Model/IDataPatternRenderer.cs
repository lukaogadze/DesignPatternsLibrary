using System.Collections.Generic;

namespace AdapterDemo.Model
{
    public interface IDataPatternRendererAdapter
    {
        string ListPatterns(IEnumerable<Pattern> patterns);
    }
}