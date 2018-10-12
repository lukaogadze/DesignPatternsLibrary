using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Iterator.TreeDemo
{
    public class DemoTreeBreadthFirstEnumerator<T> : IEnumerator<T>
    {
        private readonly DemoTree<T> _tree;
        private DemoTree<T> _current;
        private Queue<IEnumerator<DemoTree<T>>> _enumerators = new Queue<IEnumerator<DemoTree<T>>>();

        public DemoTreeBreadthFirstEnumerator(DemoTree<T> tree)
        {
            _tree = tree;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                Reset();
                _current = _tree;
                _enumerators.Enqueue(_current.Children().GetEnumerator());
                return true;
            }
            while (_enumerators.Count > 0)
            {
                var enumerator = _enumerators.Peek();
                if (enumerator.MoveNext())
                {
                    _current = enumerator.Current;
                    _enumerators.Enqueue(_current.Children().GetEnumerator());
                    return true;
                }
                else
                {
                    _enumerators.Dequeue();
                }
            }
            return false;
        }

        public void Reset()
        {
            _current = null;
            _enumerators.Clear();
        }

        public T Current
        {
            get { return _current.Value; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}