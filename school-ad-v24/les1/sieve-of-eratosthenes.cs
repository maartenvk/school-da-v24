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
            List<int> primes = [2];
            for (int i = 3; primes.Count < n; i++)
            {
                if (!primes.Exists(prime => i % prime == 0))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }
    }
}
