namespace AD
{
    public partial class MyStack<T> : IMyStack<T>
    {
        public MyLinkedList<T> list = new();

        public bool IsEmpty()
        {
            return list.Empty();
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new MyStackEmptyException();
            }

            T val = Top();
            list.RemoveFirst();

            return val;
        }

        public void Push(T data)
        {
            list.AddFirst(data);
        }

        public T Top()
        {
            if (IsEmpty())
            {
                throw new MyStackEmptyException();
            }

            return list.GetFirst();
        }
    }
}
