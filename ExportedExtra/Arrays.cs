using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace school_ad_v24.export
{
    public static class Arrays
    {
        public static int[] Populate(int length, int min, int max)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, "should be >= 0");
            }

            if (min > max)
            {
                throw new ArgumentOutOfRangeException(nameof(min), min, "should be <= max");
            }

            return Enumerable
                .Repeat(0, length)
                .Select(_ => Random.Shared.Next(min, max))
                .ToArray();
        }

        public static double[] Populate(int length, double min, double max)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, "should be >= 0");
            }

            if (min > max)
            {
                throw new ArgumentOutOfRangeException(nameof(min), min, "should be <= max");
            }

            return Enumerable
                .Repeat(0, length)
                .Select(_ => Random.Shared.NextDouble() * (max - min) + min)
                .ToArray();
        }

        public static int MaxIndex(int[] array)
        {
            int max_index = 0;
            int highest = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > highest)
                {
                    max_index = i;
                    highest = array[i];
                }
            }

            return max_index;
        }

        public static int MaxIndex(double[] array)
        {
            int max_index = 0;
            double highest = double.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > highest)
                {
                    max_index = i;
                    highest = array[i];
                }
            }

            return max_index;
        }

        public static int MaxValue(int[] array)
        {
            if (array.Length == 0) {
                throw new ArgumentException("sequence is empty", nameof(array));
            }

            int max = 0;
            foreach (int n in array)
            {
                if (n > max)
                {
                    max = n;
                }
            }
            
            return max;
        }

        public static double MaxValue(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("sequence is empty", nameof(array));
            }

            double max = 0;
            foreach (int n in array)
            {
                if (n > max)
                {
                    max = n;
                }
            }

            return max;
        }

        public static int CumulativeSum(int[] array, int index)
        {
            if (index >= array.Length)
            {
                throw new IndexOutOfRangeException("should be < length");
            }

            int sum = 0;
            for (int i = 0; i <= index && i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static double CumulativeSum(double[] array, int index)
        {
            if (index >= array.Length)
            {
                throw new IndexOutOfRangeException("should be < length");
            }

            double sum = 0;
            for (int i = 0; i <= index && i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static double[] MovingAverage(double[] array, int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), n, "cannot take average of an empty range");
            }

            double[] output = new double[array.Length];

            int left = 0;
            int right = 0;

            double sum = 0;

            while (right < array.Length)
            {
                int length = right - left + 1;
                sum += array[right];

                if (left != 0)
                {
                    sum -= array[left - 1];
                }

                output[right] = sum / length;

                // Proceed to next iteration, and clamp indices to [0..]
                right++;
                left = Math.Max(right - n + 1, 0);
            }

            return output;
        }

        public static int[] MergeArrays(int[] a, int[] b)
        {
            int[] merged = new int[a.Length + b.Length];

            int l = 0;
            int r = 0;

            for (int i = 0; i < merged.Length; i++)
            {
                int x = l < a.Length ? a[l] : int.MaxValue;
                int y = r < b.Length ? b[r] : int.MaxValue;

                int lowest = x;
                if (x < y)
                {
                    l++;
                }
                else
                {
                    r++;
                    lowest = y;
                }

                merged[i] = lowest;
            }

            return merged;
        }

        public static void MergeArraysInPlace(ref int[] array, int left, int middle, int right)
        {
            int length = middle - left;
            int offset = left;

            int[] merged = new int[length];

            int l = left;
            int r = middle;

            for (int i = 0; i < merged.Length; i++)
            {
                int x = l < middle ? array[l] : int.MaxValue;
                int y = r < right ? array[r] : int.MaxValue;

                int lowest = x;
                if (x < y)
                {
                    l++;
                }
                else
                {
                    r++;
                    lowest = y;
                }

                merged[i] = lowest;
            }

            for (int i = 0; i < length; i++)
            {
                array[offset + i] = merged[i];
            }
        }
    }
}
