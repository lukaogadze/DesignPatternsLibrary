using System.Collections;
using System.Collections.Generic;

namespace Iterator.TreeDemo
{
    public class DemoTreeEnumerator<T> : IEnumerator<T>
    {
        private DemoTree<T> _tree;
        private DemoTree<T> _current;
        private DemoTree<T> _previous;
        private Stack<DemoTree<T>> _breadcrumb = new Stack<DemoTree<T>>();

        public DemoTreeEnumerator(DemoTree<T> tree)
        {
            _tree = tree;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if(_current==null)
            {
                Reset();
                _current = _tree;
                return true;
            }
            if (_current.LeftChild != null)
            {
                return TraverseLeft();
            }
            if (_current.RightChild != null)
            {
                return TraverseRight();
            }
            return TraverseUpAndRight();
        }

        private bool TraverseUpAndRight()
        {
            if (_breadcrumb.Count > 0)
            {
                _previous = _current;
                while (true)
                {
                    _current = _breadcrumb.Pop();
                    if (_previous != _current.RightChild) break;
                }
                if (_current.RightChild != null)
                {
                    _breadcrumb.Push(_current);
                    _current = _current.RightChild;
                    return true;
                }
            }
            return false;
        }

        private bool TraverseLeft()
        {
            _breadcrumb.Push(_current);
            _current = _current.LeftChild;
            return true;
        }

        private bool TraverseRight()
        {
            _breadcrumb.Push(_current);
            _current = _current.RightChild;
            return true;
        }


        public void Reset()
        {
            _current = null;
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