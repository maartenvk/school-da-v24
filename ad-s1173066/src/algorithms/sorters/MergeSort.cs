using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace AD
{
    public partial class MergeSort : Sorter
    {
        public int[] SortArray(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            (var a, var b) = Split(array);

            a = SortArray(a);
            b = SortArray(b);

            return Merge(a, b);
        }

        public (int[], int[]) Split(int[] array)
        {
            int middle = array.Length / 2;
            int[] a = new int[middle];
            int[] b = new int[array.Length - middle];

            for (int i = 0; i < middle; i++)
            {
                a[i] = array[i];
            }

            for (int i = middle; i < array.Length; i++)
            {
                b[i - middle] = array[i];
            }

            return (a, b);
        }

        public int[] Merge(int[] a, int[] b)
        {
            int[] result = new int[a.Length + b.Length];

            int l = 0, r = 0;

            for (int i = 0; i < result.Length; i++)
            {
                int x = l < a.Length ? a[l] : int.MaxValue;
                int y = r < b.Length ? b[r] : int.MaxValue;

                int lowest;
                if (x > y)
                {
                    lowest = y;
                    r++;
                } else
                {
                    lowest = x;
                    l++;
                }

                result[i] = lowest;
            }

            return result;
        }

        public override void Sort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return;
            }

            var result = SortArray(list.ToArray()).ToList();
            list.Clear();
            list.AddRange(result);
        }
    }
}
