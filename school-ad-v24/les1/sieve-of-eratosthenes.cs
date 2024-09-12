using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_ad_v24.les1
{
    internal class Sieve_of_eratosthenes
    {
        public static List<int> Solve(int n)
        {
            List<int> numbers = Enumerable.Range(2, n).ToList();
            List<bool> scrapped = Enumerable.Repeat(false, numbers.Count).ToList();

            List<int> primes = [];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (scrapped[i])
                {
                    continue;
                }

                primes.Add(numbers[i]);
                for (int j = i; j < numbers.Count; j++)
                {
                    if (!scrapped[j] && numbers[j] % numbers[i] == 0)
                    {
                        scrapped[j] = true;
                    }
                }
            }

            //for (int i = 3; primes.Count < n; i++)
            //{
            //    if (!primes.Exists(prime => i % prime == 0))
            //    {
            //        primes.Add(i);
            //    }
            //}

            return primes;
        }
    }
}
