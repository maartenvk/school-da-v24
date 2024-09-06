using System;
using System.Collections.Generic;
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
            Contract.Assert(length >= 0);
            Contract.Assert(min < max);

            return Enumerable
                .Repeat(0, length)
                .Select(_ => Random.Shared.Next(min, max))
                .ToArray();
        }

        public static double[] Populate(int length, double min, double max)
        {
            Contract.Assert(length >= 0);
            Contract.Assert(min < max);

            return Enumerable
                .Repeat(0, length)
                .Select(_ => Random.Shared.NextDouble() * (max - min) + min)
                .ToArray();
        }

        public static int MaxIndex<T>(T[] array) where T : INumber<T>, IMinMaxValue<T>
        {
            Contract.Assert(array.Length > 0);

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
            Contract.Assert(array.Length > 0);

            return array.Max() ?? T.MinValue;
        }

        public static T CumulativeSum<T>(T[] array, int index) where T : INumber<T>, IMinMaxValue<T>
        {
            Contract.Assert(index >= 0);
            Contract.Assert(index < array.Length);

            T sum = T.Zero;
            for (int i = 0; i <= index; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static double[] MovingAverage(double[] array, int n)
        {
            Contract.Assert(n > 0);
            Contract.Assert(array.Length > 0);

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
