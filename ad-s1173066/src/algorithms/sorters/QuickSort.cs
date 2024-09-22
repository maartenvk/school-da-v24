using System.Collections.Generic;
using System.Linq;
using System;

namespace AD
{
    public partial class QuickSort : Sorter
    {
        private static int CUTOFF = 3;

        private static bool Between(int l, int c, int r)
        {
            return l <= c && c <= r;
        }

        private int MedianOfThree(List<int> list, int lo, int hi)
        {
            int length = hi - lo;
            if (length == 0)
            {
                throw new ArgumentException("Median of Three on empty list");
            }

            int mid = length / 2 + lo;

            int l = list[lo];
            int c = list[mid];
            int r = list[hi - 1];

            int pivot = r; // already on the right? No swap
            if (Between(l, c, r) || Between(r, c, l))
            {
                pivot = c;

                list[hi - 1] = c;
                list[mid] = r;
            }
            else if (Between(c, l, r) || Between(r, l, c))
            {
                pivot = l;

                list[lo] = r;
                list[hi - 1] = l;
            }

            return pivot;
        }

        public override void Sort(List<int> list)
        {
            Sort(list, 0, list.Count);
        }

        private static InsertionSort insertionSorter = new();

        public void Sort(List<int> list, int lo, int hi)
        {
            int length = hi - lo;
            if (length <= CUTOFF)
            {
                insertionSorter.Sort(list, lo, hi);
                return;
            }

            int pivot = MedianOfThree(list, lo, hi);

            int i = lo, j = hi - 2;

            while (true)
            {
                while (list[i] <= pivot && i < hi)
                {
                    i++;
                }

                while (list[j] >= pivot && j > lo)
                {
                    j--;
                }

                if (j < i)
                {
                    break;
                }

                // swap at i, j
                (list[i], list[j]) = (list[j], list[i]);
            }

            (list[i], list[hi - 1]) = (list[hi - 1], list[i]);

            int center = i;
            Sort(list, lo, center);
            Sort(list, center + 1, hi);
        }
    }
}
