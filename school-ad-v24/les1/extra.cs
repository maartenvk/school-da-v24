using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace school_ad_v24.les1
{
    class FizzBuzz
    {
        public static Predicate<int> MatchesFizz = n => n % 3 == 0;
        public static Predicate<int> MatchesBuzz = n => n % 5 == 0;
        public static Predicate<int> MatchesFizzBuzz = n => MatchesFizz(n) && MatchesBuzz(n);

        public static void PrintRange(int low, int high)
        {
            for (int i = low; i <= high; i++)
            {
                if (MatchesFizzBuzz(i))
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (MatchesFizz(i))
                {
                    Console.WriteLine("Fizz");
                }
                else if (MatchesBuzz(i))
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }

    class ArrayUtils
    {
        // max is EXCLUDING
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

        public static int MaxIndex<T>(T[] array) where T: INumber<T>, IMinMaxValue<T>
        {
            Contract.Assert(array.Length >= 0);
            
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

        public static T MaxValue<T>(T[] array) where T: INumber<T>, IMinMaxValue<T>
        {
            Contract.Assert(array.Length >= 0);

            return array.Max() ?? T.MinValue;
        }
    }

    class Benchmarker<T> where T: Delegate
    {
        private readonly Stopwatch stopwatch = new();
        private readonly T function;

        public Benchmarker(T function)
        {
            this.function = function;
        }

        public void InvokeFunction(params object?[]? args)
        {
            _ = function.DynamicInvoke(args);
        }

        public void Run(int quality)
        {
            long[] elapsed = new long[quality];

            for (int i = 0; i < quality; i++)
            {
                stopwatch.Restart();
                InvokeFunction();
                
                stopwatch.Stop();
                elapsed[i] = stopwatch.ElapsedTicks;
            }
        }
    }
}
