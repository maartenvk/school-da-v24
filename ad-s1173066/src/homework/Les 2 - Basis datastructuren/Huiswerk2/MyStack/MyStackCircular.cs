namespace AD.MyStack
{
    public class MyStackFilledException : System.Exception { }

    public partial class MyStackCircular<T> : IMyStack<T>
    {
        private readonly T[] array;

        public int Capacity { get; init; }
        public int Used { get; private set; }

        public MyStackCircular(int capacity)
        {
            Capacity = capacity;
            array = new T[capacity];
            Used = 0;
        }

        public bool IsEmpty()
        {
            return Used == 0;
        }

        public bool IsFull()
        {
            return Used == Capacity;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new MyStackEmptyException();
            }

            return array[--Used];
        }

        public void Push(T data)
        {
            if (IsFull())
            {
                throw new MyStackFilledException();
            }

            array[Used++] = data;
        }

        public T Top()
        {
            if (IsEmpty())
            {
                throw new MyStackEmptyException();
            }

            return array[Used - 1];
        }
    }
}
