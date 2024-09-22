using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.MyQueue
{
    public class MyQueueFilledException : Exception { }

    public class MyQueueCircular<T> : IMyQueue<T>
    {
        private readonly T[] array;
        private readonly int capacity;
        private int front, back;
        private int size;

        public MyQueueCircular(int capacity)
        {
            this.capacity = capacity;
            array = new T[capacity];
            front = 0;
            back = 0;
            size = 0;
        }

        public void Clear()
        {
            front = 0;
            back = 0;
            size = 0;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new MyQueueEmptyException();
            }

            T item = array[front++];
            if (front >= capacity)
            {
                front = 0;
            }

            size--;
            return item;
        }

        public void Enqueue(T data)
        {
            if (IsFull())
            {
                throw new MyQueueFilledException();
            }

            array[back++] = data;
            if (back >= capacity)
            {
                back = 0;
            }

            size++;
        }

        public T GetFront()
        {
            if (IsEmpty())
            {
                throw new MyQueueEmptyException();
            }

            return array[front];
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public bool IsFull()
        {
            return size == capacity;
        }
    }
}
