using System;
using System.Collections;
using System.Linq;

namespace AD.MyArrayListGeneric
{
    public partial class MyArrayListGeneric<T> : AD.MyArrayListGeneric.IMyArrayListGeneric<T>
    {
        private T[] data;
        private int size;
        private int capacity;

        // O(1)
        public MyArrayListGeneric(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Size cannot be negative");
            }

            data = new T[capacity];
            size = 0;
            this.capacity = capacity;
        }

        // O(1)
        public void Add(T val)
        {
            if (size == capacity)
            {
                throw new MyArrayListGenericFullException();
            }

            data[size++] = val;
        }

        // O(1)
        public T Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new MyArrayListGenericIndexOutOfRangeException();
            }

            return data[index];
        }

        // O(1)
        public void Set(int index, T val)
        {
            if (index < 0 || index >= size)
            {
                throw new MyArrayListGenericIndexOutOfRangeException();
            }

            data[index] = val;
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
        public int CountOccurences(T val)
        {
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                if (data[i]!.Equals(val))
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
