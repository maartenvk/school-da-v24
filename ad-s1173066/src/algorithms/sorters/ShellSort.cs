using System.Collections.Generic;

namespace AD
{
    public partial class ShellSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            var sorter = new InsertionSort();

            int gap = list.Count / 2;
            while (gap > 0)
            {
                for (int offset = 0; offset < gap; offset++)
                {
                    // collect all elements at gap
                    List<int> elements = new();

                    for (int i = 0; (offset + i) < list.Count; i += gap)
                    {
                        elements.Add(list[offset + i]);
                    }

                    sorter.Sort(elements);

                    for (int i = 0, j = 0; (offset + i) < list.Count; i += gap, j++)
                    {
                        list[offset + i] = elements[j];
                    }
                }

                gap /= 2;
            }

            sorter.Sort(list);
        }
    }
}
