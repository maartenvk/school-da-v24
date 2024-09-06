using school_ad_v24.export;

namespace ExportedTester
{
    public class CumulativeSum
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 21)]
        [TestCase(new int[] { 7, 2, 3, 4, 5, 6 }, 27)]
        [TestCase(new int[] { 7, 2, 8, 4, 5, 6 }, 32)]
        public void CumulativeSumIsCorrect(int[] array, int expected)
        {
            Assert.That(Arrays.CumulativeSum(array, array.Length - 1), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new double[] { 1, 2, 3, 4, 5, 6 }, 21)]
        [TestCase(new double[] { 7, 2, 3, 4, 5, 6 }, 27)]
        [TestCase(new double[] { 7, 2, 8, 4, 5, 6 }, 32)]
        public void CumulativeSumIsCorrectDouble(double[] array, double expected)
        {
            Assert.That(Arrays.CumulativeSum(array, array.Length - 1), Is.EqualTo(expected));
        }

        [Test]
        public void CumulativeSumSupportsOutOfRangeIndex()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = Arrays.CumulativeSum([1, 2, 3], 99);
            });
        }
    }
}
