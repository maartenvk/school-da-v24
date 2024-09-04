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

    class Benchmarker
    {
        private readonly Stopwatch stopwatch = new();
        private readonly Delegate function;
        private readonly Func<int, dynamic> paramsSupplier;

        public int Quality { get; private set; }
        public int[] Ns { get; private set; }
        public long[] Data { get; private set; }

        public Benchmarker(Delegate function, Func<int, dynamic> paramsSupplier)
        {
            this.function = function;
            this.paramsSupplier = paramsSupplier;
        }

        private void InvokeFunction(dynamic args)
        {
            _ = function.DynamicInvoke(args);
        }

        public void Run(int quality, int fromN, int toN)
        {
            RunFor(quality, Enumerable.Range(fromN, (toN - fromN) + 1).ToArray());
        }

        public void RunForTwos(int quality, int count)
        {
            Contract.Assert(count > 0);
            var list = Enumerable.Range(1, count).Select((n) => (int)Math.Pow(2, n)).ToArray();

            RunFor(quality, list);
        }

        public void RunFor(int quality, int[] Ns)
        {
            this.Ns = Ns;
            Quality = quality;
            Data = new long[Ns.Length];

            int nIndex = 0;
            foreach (int n in Ns)
            {
                Console.Write($"O({n}) ");

                long[] data = new long[quality];
                for (int i = 0; i < quality; i++)
                {
                    var args = paramsSupplier(n);

                    stopwatch.Restart();
                    InvokeFunction(args);

                    stopwatch.Stop();
                    data[i] = stopwatch.ElapsedMilliseconds;
                    Console.Write('.');
                }

                long ms = data.Sum() / quality;
                Data[nIndex++] = ms;
                Console.WriteLine($" {ms} ms");
            }
        }

        public void PrintAsCopyable()
        {
            Console.WriteLine('[' + string.Join(',', Data) + ']');
        }
    }
}
