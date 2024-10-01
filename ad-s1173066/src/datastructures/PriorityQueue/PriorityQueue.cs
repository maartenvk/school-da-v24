using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Text;


namespace AD
{
    public partial class PriorityQueue<T> : IPriorityQueue<T>
        where T : IComparable<T>
    {
        public const int DEFAULT_CAPACITY = 100;

        public int capacity;
        public int size;   // Number of elements in heap
        public T[] array;  // The heap array

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public PriorityQueue()
        {
            capacity = DEFAULT_CAPACITY;
            array = new T[capacity + 1];
            size = 0;
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

        public bool HasParent(int index)
        {
            return index != 1;
        }

        public int ParentOf(int index)
        {
            return index / 2;
        }

        public (int, int) ChildrenOf(int index)
        {
            int childLeft = index * 2;
            int childRight = index * 2 + 1;
            return (childLeft, childRight);
        }

        public void PercolateUp(int index)
        {

        }

        public void PercolateDown(int index)
        {

        }

        protected void AssertBigEnough()
        {
            int newSize = size + 1;
            if (newSize <= capacity)
            {
                return;
            }

            int newCapacity = capacity + capacity / 2; // GCC style
            T[] newArray = new T[newCapacity + 1];
            for (int i = 0; i < (capacity + 1); i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
            capacity = newCapacity;
        }

        public void Add(T x)
        {
            AssertBigEnough();

            array[size] = x;
            size++;

            PercolateUp();
        }

        public T this[int index]
        {
            get => array[index - 1];
            set => array[index - 1] = value;
        }

        // Removes the smallest item in the priority queue
        public T Remove()
        {
            if (IsEmpty())
            {
                throw new PriorityQueueEmptyException();
            }

            T result = array[0];
            array[0] = array[size];
            size--;

            PercolateDown(0);
            return result;
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void AddFreely(T x)
        {
            AssertBigEnough();

            array[size] = x;
            size++;
        }

        public void BuildHeap()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "";
            }

            StringBuilder sb = new();
            for (int i = 0; i < size; i++)
            {
                sb.Append(array[i]);
                sb.Append(' ');
            }


            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}
