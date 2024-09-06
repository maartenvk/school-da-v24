using school_ad_v24.export;

namespace ExportedTester
{
    public class MergeArrays
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 1, 2 }, new int[] { 3, 4 }, ExpectedResult = new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 5, 6 }, new int[] { 3, 4 }, ExpectedResult = new int[] { 3, 4, 5, 6 })]
        [TestCase(new int[] { 5, 6 }, new int[] {}, ExpectedResult = new int[] { 5, 6 })]
        [TestCase(new int[] {}, new int[] { 5, 6 }, ExpectedResult = new int[] { 5, 6 })]
        public int[] CanMerge(int[] a, int[] b)
        {
            return Arrays.MergeArrays(a, b);
        }
    }
}
