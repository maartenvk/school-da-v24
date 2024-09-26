using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_ad_v24.les3
{
    public static class Recursion
    {
        public static int Sum(int n)
        {
            if (n <= 9)
            {
                return n;
            }

            return n % 10 + Sum(n / 10);
        }

        public static string Reverse(string s)
        {
            if (s == "")
            {
                return s;
            }

            return s[^1] + Reverse(s.Remove(s.Length - 1));
        }
    }
}
