using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_ad_v24.export
{
    public class Benchmarker
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
            Ns = [];
            Data = [];
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
