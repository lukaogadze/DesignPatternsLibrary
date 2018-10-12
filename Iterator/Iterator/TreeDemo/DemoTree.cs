using System;
using System.Collections;
using System.Collections.Generic;

namespace Iterator.TreeDemo
{
    [Serializable]
    public class DemoTree<T> : IEnumerable<T>
    {
        /// <summary>
        /// Needed for serialization to work
        /// </summary>
        public DemoTree()
        {
        }
        public DemoTree(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public DemoTree<T> LeftChild { get; set; }
        public DemoTree<T> RightChild { get; set; }

        public void Add(T value)
        {
            if (LeftChild == null)
            {
                LeftChild = new DemoTree<T>(value);
                return;
            }
            if (RightChild == null)
            {
                RightChild = new DemoTree<T>(value);
                return;
            }
            if (LeftChild.Depth() <= RightChild.Depth())
            {
                LeftChild.Add(value);
                return;
            }
            RightChild.Add(value);
        }

        /// <summary>
        /// Determines the depth of the next vacant position in the tree
        /// </summary>
        /// <returns></returns>
        public int Depth()
        {
            if (LeftChild == null || RightChild == null)
            { return 0; }
            return 1 + Math.Max(LeftChild.Depth(), RightChild.Depth());
        }

        public IEnumerable<DemoTree<T>> Children()
        {
            if(LeftChild != null)
            {
                yield return LeftChild;
            }
            if(RightChild != null)
            {
                yield return RightChild;
            }
            yield break;
        }

        /// <summary>
        /// Iterates over the tree in depth-first fashion and returns a list of the tree's values
        /// </summary>
        /// <returns></returns>
        public List<T> ToList()
        {
            var myList = new List<T>();
            myList.Add(Value);
            if (LeftChild != null)
            {
                myList.AddRange(LeftChild.ToList());
            }
            if (RightChild != null)
            {
                myList.AddRange(RightChild.ToList());
            }
            return myList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (UseBreadthFirstEnumerator)
            {
                return new DemoTreeBreadthFirstEnumerator<T>(this);
            }
            return new DemoTreeEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool UseBreadthFirstEnumerator { get; set; }
    }
}