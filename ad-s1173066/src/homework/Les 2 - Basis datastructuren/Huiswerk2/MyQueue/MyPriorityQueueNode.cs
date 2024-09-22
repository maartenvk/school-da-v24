namespace AD.MyQueue
{
    public partial class MyPriorityQueueNode<T>
    {
        public T data;
        public int priority { get; private set; }
        public MyPriorityQueueNode<T>? next;

        public MyPriorityQueueNode(T data, int priority = 0, MyPriorityQueueNode<T>? next = null)
        {
            this.data = data;
            this.priority = priority;
            this.next = next;
        }

        public override string ToString()
        {
            return $"({data},{priority})";
        }
    }
}
