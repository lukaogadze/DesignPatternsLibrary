using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace AdapterDemo.Model
{
    public class PatternRenderer
    {
        private readonly IDataPatternRendererAdapter _dataPatternRenderer;

        public PatternRenderer(IDataPatternRendererAdapter dataPatternRenderer)
        {
            _dataPatternRenderer = dataPatternRenderer;
        }

        public PatternRenderer() : this(new DataPatternRendererAdapter())
        {

        }

        public string ListPatterns(IEnumerable<Pattern> patterns)
        {
            return _dataPatternRenderer.ListPatterns(patterns);
        }
    }
}