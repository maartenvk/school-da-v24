using System;

namespace AD
{
    public class Opgave1
    {
        // factorial: 4! = 4*3*2*1

        public static long FacRecursive(int n)
        {
            if (n < 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(n), n, "Must be a positive integer");
            }

            if (n == 1)
            {
                return 1;
            }

            return n * FacRecursive(n - 1);
        }

        private static ICache<int, long> FacRecursiveCached__cache = new LRUCache<int, long>(26);
        public static Func<int, long> FacRecursiveCached = Caching.MakeCached<int, long>((int n) =>
        {
            if (n < 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(n), n, "Must be a positive integer");
            }

            if (n == 1)
            {
                return 1;
            }

            return n * FacRecursiveCached(n - 1);
        }, cache: FacRecursiveCached__cache);

        public static long FacIterative(int n)
        {
            if (n < 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(n), n, "Must be a positive integer");
            }

            long result = n--;
            while (n > 1)
            {
                result *= n--;
            }

            return result;
        }

        public static void Run()
        {
            //------------------------------------------------------------
            // The factorial of 21 is too high to fit in a "long". That's
            // why from n=21, the result is negative
            //------------------------------------------------------------
            int MAX = 22;

            System.Console.WriteLine("Iteratief:");
            for (int n = 1; n < MAX; n++)
            {
                System.Console.WriteLine("          {0,2}! = {1,20}", n, FacIterative(n));
            }
            System.Console.WriteLine("Recursief:");
            for (int n = 1; n < MAX; n++)
            {
                System.Console.WriteLine("          {0,2}! = {1,20}", n, FacRecursive(n));
            }
            System.Console.WriteLine("Recursief (CACHED):");
            for (int n = 1; n < MAX; n++)
            {
                System.Console.WriteLine("          {0,2}! = {1,20}", n, FacRecursiveCached(n));
            }

        }
    }
}
