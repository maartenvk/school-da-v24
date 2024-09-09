using school_ad_v24.export;

namespace ExportedTester
{
    public class MergeArraysInPlace
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase((int[])[0], 0, 1, 1, ExpectedResult = (int[])[0])]
        [TestCase((int[])[6, 1, 3, 6], 0, 1, 2, ExpectedResult = (int[])[1, 6, 3, 6])]
        [TestCase((int[])[1, 6, 7, 9], 0, 2, 4, ExpectedResult = (int[])[1, 6, 7, 9])]
        public int[] CanMerge(int[] array, int left, int middle, int right)
        {
            Arrays.MergeArraysInPlace(ref array, left, middle, right);
            return array;
        }
    }
}
