using System.Collections.Generic;


namespace AD
{
    public partial class InsertionSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            Sort(list, 0, list.Count);
        }

        public void Sort(List<int> list, int lo, int hi)
        {
            for (int i = lo + 1; i < hi; i++)
            {
                int j = i;
                while (j > lo && list[j - 1] > list[j])
                {
                    (list[j], list[j - 1]) = (list[j - 1], list[j]);
                    j--;
                }
            }
        }
    }
}
