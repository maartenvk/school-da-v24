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

        public static int MaxIndex<T>(T[] array) where T : INumber<T>, IMinMaxValue<T>
        {
            int max_index = 0;
            T highest = T.MinValue;

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

        public static T MaxValue<T>(T[] array) where T : INumber<T>, IMinMaxValue<T>
        {
            if (array.Length == 0) {
                throw new ArgumentException("sequence is empty", nameof(array));
            }

            return array.Max()!;
        }

        public static T CumulativeSum<T>(T[] array, int index) where T : INumber<T>, IMinMaxValue<T>
        {
            if (index >= array.Length)
            {
                throw new IndexOutOfRangeException("should be < length");
            }

            T sum = T.Zero;
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

        public static T[] MergeArrays<T>(T[] a, T[] b) where T : INumber<T>, IComparable<T>, IMinMaxValue<T>
        {
            T[] merged = new T[a.Length + b.Length];

            int l = 0;
            int r = 0;

            for (int i = 0; i < merged.Length; i++)
            {
                T x = l < a.Length ? a[l] : T.MaxValue;
                T y = r < b.Length ? b[r] : T.MaxValue;

                T lowest = x;
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
    }
}
