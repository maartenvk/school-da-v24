using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Text;


namespace AD
{
    public partial class PriorityQueue<T> : IPriorityQueue<T>
        where T : IComparable<T>
    {
        public const int DEFAULT_CAPACITY = 2;

        public int size;   // Number of elements in heap
        public T[] array;  // The heap array

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public PriorityQueue()
        {
            array = new T[DEFAULT_CAPACITY];
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

        public (bool, bool) HasChildren(int index)
        {
            (int left, int right) child = ChildrenOf(index);
            return (child.left < (1 + size), child.right < (1 + size));
        }

        public (int, int) ChildrenOf(int index)
        {
            int childLeft = index * 2;
            int childRight = index * 2 + 1;
            return (childLeft, childRight);
        }

        public void Swap(int lindex, int rindex)
        {
            (array[lindex], array[rindex]) = (array[rindex], array[lindex]);
        }

        public void PercolateUp(int index)
        {
            // item to be moved => [index]
            if (!HasParent(index))
            {
                return;
            }

            int parentIndex = ParentOf(index);
            T parentValue = array[parentIndex];
            T value = array[index];

            if (value.CompareTo(parentValue) >= 0)
            {
                return;
            }

            Swap(parentIndex, index);
            PercolateUp(parentIndex);
        }

        public void PercolateDown(int index)
        {
            (bool left, bool right) childExists = HasChildren(index);
            if (!childExists.left && !childExists.right)
            {
                return;
            }

            T value = array[index];

            (int left, int right) childIndex = ChildrenOf(index);

            (T left, T right) childValue = (array[childIndex.left], default(T));
            if (childExists.right)
            {
                childValue.right = array[childIndex.right];
            }

            bool leftIsSmaller = !childExists.right || childValue.right.CompareTo(childValue.left) < 0; ;

            T comparisonValue = leftIsSmaller ? childValue.left : childValue.right;
            if (value.CompareTo(comparisonValue) < 0)
            {
                return;
            }

            int swapIndex = leftIsSmaller ? childIndex.left : childIndex.right;
            Swap(swapIndex, index);
            PercolateDown(swapIndex);
        }

        protected void AssertEnoughSizeForAdding()
        {
            int capacity = array.Length;

            // add offset (1) and new item (1)
            int expectedCapacity = 1 + size + 1;
            if (expectedCapacity <= capacity)
            {
                return;
            }

            int newCapacity = capacity * 2; // Clang style
            T[] newArray = new T[newCapacity];
            for (int i = 0; i < capacity; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }

        public void Add(T x)
        {
            AssertEnoughSizeForAdding();

            array[1 + size] = x;
            size++;

            PercolateUp(1 + (size - 1));
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

            T result = array[1];
            array[1] = array[1 + (size - 1)];
            size--;

            PercolateDown(1);
            return result;
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void AddFreely(T x)
        {
            AssertEnoughSizeForAdding();

            array[1 + size] = x;
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
                sb.Append(array[1 + i]);
                sb.Append(' ');
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}
