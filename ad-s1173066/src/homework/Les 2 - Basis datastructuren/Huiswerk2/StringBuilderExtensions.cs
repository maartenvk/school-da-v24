using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class StringBuilderExtensions
    {
        public static void Pop(this StringBuilder sb)
        {
            sb.Remove(sb.Length - 1, 1);
        }
    }
}
