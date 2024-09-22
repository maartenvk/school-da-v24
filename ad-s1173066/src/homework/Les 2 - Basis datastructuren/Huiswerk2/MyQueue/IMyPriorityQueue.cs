namespace AD
{
    public partial interface IMyPriorityQueue<T>
    {
        bool IsEmpty();
        void Enqueue(T data, int priority = 0);
        T GetFront();
        T Dequeue();
        void Clear();
    }

    public class MyPriorityQueueEmptyException : System.Exception
    {
    }
}