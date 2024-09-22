using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD._Tree
{
    public interface ITree<T> where T : IComparable<T>
    {
        public void Insert(T item);
        public void Remove(T item);
        public bool Contains(T item);
        public Node<T>? Find(T item);
        public Node<T> Head();
    }

    public class EmptyTreeException : Exception { }

    public class ElementNotInTreeException : Exception { }
}
