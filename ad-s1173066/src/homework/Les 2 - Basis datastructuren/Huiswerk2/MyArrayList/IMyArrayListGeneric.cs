using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.MyArrayListGeneric
{
    public interface IMyArrayListGeneric<T>
    {
        // Add an element to the end of the list (as long
        // as there is still capacity)
        void Add(T n);

        // Get the value from an index
        T Get(int index);

        // Set the value at a certain index
        void Set(int index, T val);

        // Returns the capacity of the list
        int Capacity();

        // Returns the size of the list
        int Size();

        // Clears the list
        void Clear();

        // Count the number of occurences in the list of a value
        int CountOccurences(T val);
    }

    public class MyArrayListGenericIndexOutOfRangeException : System.Exception
    {
    }

    public class MyArrayListGenericFullException : System.Exception
    {
    }
}
