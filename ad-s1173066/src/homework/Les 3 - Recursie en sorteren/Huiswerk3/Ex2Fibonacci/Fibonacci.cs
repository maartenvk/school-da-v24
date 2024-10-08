using System;

namespace AD
{
    public class Opgave2
    {
        static long calls = 0;

        private static long FibonacciRecursiveInternal(int n)
        {
            calls++;

            if (n < 0)
            {
                throw new System.ArgumentOutOfRangeException(nameof(n), n, "Must be a positive integer");
            }

            if (n < 2)
            {
                return n;
            }

            return FibonacciRecursiveInternal(n - 1) + FibonacciRecursiveInternal(n - 2);
        }

        public static long FibonacciRecursive(int n)
        {
            calls = 0;
            return FibonacciRecursiveInternal(n);
        }

        private static ICache<int, long> FibonacciRecursive__cache = new LRUCache<int, long>(26);
        public static Func<int, long> FibonacciRecursiveCached = Caching.MakeCached<int, long>((int n) =>
        {
            calls++;

            if (n < 0)
            {
                throw new System.ArgumentOutOfRangeException(nameof(n), n, "Must be a positive integer");
            }

            if (n < 2)
            {
                return n;
            }

            return FibonacciRecursiveCached(n - 1) + FibonacciRecursiveCached(n - 2);
        }, cache: FibonacciRecursive__cache);


        private static long FibonacciIterativeInternal(int n)
        {
            if (n < 0)
            {
                throw new System.ArgumentOutOfRangeException(nameof(n), n, "Must be a positive integer");
            }

            long result = 1;
            long prev = 0;
            for (int i = 2; i <= n; i++)
            {
                long tmp = result;
                result += prev;
                prev = tmp;
            }

            return result;
        }

        public static long FibonacciIterative(int n)
        {
            calls = 0;
            return FibonacciIterativeInternal(n);
        }

        public static void Run()
        {
            int MAX = 35;

            System.Console.WriteLine("Recursief:");
            for (int n = 1; n <= MAX; n++)
            {
                System.Console.WriteLine("          Fibonacci({0,2}) = {1,8} ({2,9} calls)", n, FibonacciRecursive(n), calls);
            }
            System.Console.WriteLine("Recursief (CACHED):");
            calls = 0;
            for (int n = 1; n <= MAX; n++)
            {
                System.Console.WriteLine("          Fibonacci({0,2}) = {1,8} ({2,9} calls)", n, FibonacciRecursiveCached(n), calls);
            }
            System.Console.WriteLine("Iteratief:");
            for (int n = 1; n <= MAX; n++)
            {
                System.Console.WriteLine("          Fibonacci({0,2}) = {1,8} ({2,9} loops)", n, FibonacciIterative(n), calls);
            }
        }
    }
}
