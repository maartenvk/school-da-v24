using System;
using System.Linq;

namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;
        private int capacity;

        // O(1)
        public MyArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Size cannot be negative");
            }

            data = new int[capacity];
            size = 0;
            this.capacity = capacity;
        }

        // O(1)
        public void Add(int n)
        {
            if (size == capacity)
            {
                throw new MyArrayListFullException();
            }

            data[size++] = n;
        }

        // O(1)
        public int Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new MyArrayListIndexOutOfRangeException();
            }

            return data[index];
        }

        // O(1)
        public void Set(int index, int n)
        {
            if (index < 0 || index >= size)
            {
                throw new MyArrayListIndexOutOfRangeException();
            }

            data[index] = n;
        }

        // O(1)
        public int Capacity()
        {
            return capacity;
        }

        // O(1)
        public int Size()
        {
            return size;
        }

        // O(1)
        public void Clear()
        {
            size = 0;
        }

        // O(n)
        public int CountOccurences(int n)
        {
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                if (data[i] == n)
                {
                    count++;
                }
            }

            return count;
        }

        // O(n)
        public override string ToString()
        {
            if (Empty())
            {
                return "NIL";
            }

            return '[' + string.Join(',', data.Take(size)) + ']';
        }

        // extensions

        // O(1)
        public bool Empty()
        {
            return size == 0;
        }
    }
}
