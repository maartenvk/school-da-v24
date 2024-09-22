using System.Text;
using ExtensionMethods;

namespace AD.MyQueue
{
    public partial class MyPriorityQueue<T> : IMyPriorityQueue<T>
    {
        private MyPriorityQueueNode<T>? front;
        private MyPriorityQueueNode<T>? back;
        private int size = 0;

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Enqueue(T data, int priority = 0)
        {
            if (size++ == 0)
            {
                front = back = new(data, priority);
                return;
            }

            MyPriorityQueueNode<T>? node = front, prev = front;
            while (node is not null && node.priority >= priority)
            {
                prev = node;
                node = node.next;
            }

            if (node is not null && node == front && priority > node.priority)
            {
                front = new(data, priority, front);
                return;
            }

            if (prev == back)
            {
                back!.next = new(data, priority);
                back = back.next;
                return;
            }

            prev!.next = new(data, priority, node);
        }

        public T GetFront()
        {
            if (IsEmpty())
            {
                throw new MyPriorityQueueEmptyException();
            }

            return front!.data;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new MyPriorityQueueEmptyException();
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
            MyPriorityQueueNode<T>? node = front;
            while (node is not null)
            {
                sb.Append(node);
                sb.Append(',');
                node = node.next;
            }

            sb.Pop();
            sb.Append(']');
            return sb.ToString();
        }
    }
}