using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD._Tree
{
    public class Node<T>
    {
        public T Data;
        public Node<T>? Left, Right;
    
        public Node(T data, Node<T>? left = null, Node<T>? right = null)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            return (Left?.ToString() ?? "") + $"[{Data}]" + (Right?.ToString() ?? "");
        }
    }
}
