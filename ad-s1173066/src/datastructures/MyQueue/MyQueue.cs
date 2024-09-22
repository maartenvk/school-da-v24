using ExtensionMethods;
using System.Text;

namespace AD
{
    public partial class MyQueue<T> : IMyQueue<T>
    {
        private MyQueueNode<T>? front;
        private MyQueueNode<T>? back;
        private int size = 0;
        
        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Enqueue(T data)
        {
            if (size++ == 0)
            {
                front = back = new(data);
                return;
            }

            back!.next = new(data);
            back = back.next;
        }

        public T GetFront()
        {
            if (IsEmpty())
            {
                throw new MyQueueEmptyException();
            }

            return front!.data;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new MyQueueEmptyException();
            }

            var val = front!.data;
            front = front.next;
            size--;

            return val;
        }

        public void Clear()
        {
            size = 0;
            (front, back) = (null, null);
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "NIL";
            }

            StringBuilder sb = new();
            sb.Append('[');
            MyQueueNode<T>? node = front;
            while (node is not null)
            {
                sb.Append(node.data);
                sb.Append(',');
                node = node.next;
            }

            sb.Pop();
            sb.Append(']');
            return sb.ToString();
        }
    }
}