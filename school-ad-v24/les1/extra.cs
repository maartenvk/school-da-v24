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

        public static T MaxValue<T>(T[] array) where T: INumber<T>, IMinMaxValue<T>
        {
            Contract.Assert(array.Length > 0);

            return array.Max() ?? T.MinValue;
        }

        public static T CumulativeSum<T>(T[] array, int index) where T: INumber<T>, IMinMaxValue<T>
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

        public static double[] MovingAverageNaive(double[] array, int n)
        {
            Contract.Assert(n > 0);
            Contract.Assert(array.Length > 0);

            double[] output = new double[array.Length];

            int left = 0;
            int right = 0;

            while (right < array.Length)
            {
                int length = right - left + 1;
                double sum = 0;
                for (int i = left; i <= right; i++)
                {
                    sum += array[i];
                }

                sum /= length;
                output[right] = sum;

                // Proceed to next iteration, and clamp indices to [0..]
                right++;
                left = Math.Max(right - n + 1, 0);
            }

            return output;
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

        public static void Initialize(Action initializer)
        {
            Console.WriteLine("Initializing..");
            initializer.Invoke();
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

        public void RunStep(int quality, int from, int to, int step)
        {
            Contract.Assert(step > 0);
            Contract.Assert(to > from);

            int length = (to - from) / step;

            var Ns = Enumerable.Repeat(0, length).Select((_, i) =>
            {
                return from + i * step;
            }).ToArray();

            RunFor(quality, Ns);
        }

        public void RunFor(int quality, int[] Ns)
        {
            Contract.Assert(quality > 0);
            
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
