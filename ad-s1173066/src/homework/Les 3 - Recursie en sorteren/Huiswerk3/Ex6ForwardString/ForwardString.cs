using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD
{
    public class Opgave6
    {
        public static void PopLast(ref StringBuilder sb)
        {
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
        }

        public static string ForwardString(List<int> list, int from_index)
        {
            if (from_index < 0)
            {
                from_index = 0;
            }

            StringBuilder sb = new();
            for (int i = from_index; i < list.Count; i++)
            {
                sb.Append(list[i]);
                sb.Append(' ');
            }

            PopLast(ref sb);
            return sb.ToString();
        }
        
        public static string BackwardString(List<int> list, int from_index)
        {
            if (from_index < 0)
            {
                from_index = 0;
            }

            StringBuilder sb = new();
            for (int i = list.Count - 1; i >= from_index; i--)
            {
                sb.Append(list[i]);
                sb.Append(' ');
            }

            PopLast(ref sb);
            return sb.ToString();
        }

        public static void Run()
        {
            List<int> list = new List<int>(new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11});

            System.Console.WriteLine(ForwardString(list, 3));
            System.Console.WriteLine(ForwardString(list, 7));
            System.Console.WriteLine(BackwardString(list, 3));
            System.Console.WriteLine(BackwardString(list, 7));
        }
    }
}
