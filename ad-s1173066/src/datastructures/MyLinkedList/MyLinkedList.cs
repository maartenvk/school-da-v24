using System.Text;

namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {

        public MyLinkedListNode<T>? first;
        private int size;

        public MyLinkedList()
        {
            size = 0;
        }

        public void AddFirst(T data)
        {
            first = new(data, first);
            size++;
        }

        public bool Empty()
        {
            return size == 0;
        }

        public T GetFirst()
        {
            if (Empty())
            {
                throw new MyLinkedListEmptyException();
            }

            return first!.data;
        }

        public void RemoveFirst()
        {
            if (Empty())
            {
                throw new MyLinkedListEmptyException();
            }

            first = first!.next;
            size--;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            first = null;
            size = 0;
        }

        public void Insert(int index, T data)
        {
            bool isLast = index == size; // index equal to size implies add at end
            if (index < 0 || index > size)
            {
                throw new MyLinkedListIndexOutOfRangeException();
            }

            if (Empty())
            {
                first = new(data);
                size++;
                return;
            }

            if (index == 0)
            {
                first = new(data, first);
                size++;
                return;
            }

            MyLinkedListNode<T>? node = first, prev = first;

            while (index-- > 0)
            {
                prev = node;
                node = node!.next;
            }

            if (node is null)
            {
                prev!.next = new(data);
                size++;
                return;
            }

            prev!.next = new(data, node);
            size++;
        }

        public override string ToString()
        {
            if (Empty())
            {
                return "NIL";
            }

            StringBuilder sb = new();
            sb.Append('[');

            MyLinkedListNode<T>? node = first;
            while (node is not null)
            {
                sb.Append(node!.data!.ToString());
                sb.Append(',');
                node = node.next;
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');

            return sb.ToString();
        }
    }
}