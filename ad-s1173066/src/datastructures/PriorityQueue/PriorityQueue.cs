using System;


namespace AD
{
    public partial class PriorityQueue<T> : IPriorityQueue<T>
        where T : IComparable<T>
    {
        public const int DEFAULT_CAPACITY = 100;
        public int size;   // Number of elements in heap
        public T[] array;  // The heap array

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public PriorityQueue()
        {
            array = new T[DEFAULT_CAPACITY];
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------
        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            size = 0;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Add(T x)
        {
            if (size >= DEFAULT_CAPACITY)
            {
                throw new System.Exception("Already at full capacity");
            }

            throw new System.NotImplementedException();
        }

        // Removes the smallest item in the priority queue
        public T Remove()
        {
            if (IsEmpty())
            {
                throw new PriorityQueueEmptyException();
            }

            throw new System.NotImplementedException();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void AddFreely(T x)
        {
            throw new System.NotImplementedException();
        }

        public void BuildHeap()
        {
            throw new System.NotImplementedException();
        }
    }
}
