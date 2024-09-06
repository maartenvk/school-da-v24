using school_ad_v24.export;

namespace ExportedTester
{
    public class MaxIndex
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 5)]
        [TestCase(new int[] { 7, 2, 3, 4, 5, 6 }, 0)]
        [TestCase(new int[] { 7, 2, 8, 4, 5, 6 }, 2)]
        public void FindsInt(int[] array, int expected)
        {
            Assert.That(Arrays.MaxIndex(array), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new double[] { 1, 2, 3, 4, 5, 6 }, 5)]
        [TestCase(new double[] { 7, 2, 3, 4, 5, 6 }, 0)]
        [TestCase(new double[] { 7, 2, 8, 4, 5, 6 }, 2)]
        public void FindsDouble(double[] array, int expected)
        {
            Assert.That(Arrays.MaxIndex(array), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1, 64)]
        [TestCase(6, 32)]
        public void FindsIntAllEqual(int el, int n)
        {
            int index = Arrays.MaxIndex(Enumerable.Repeat(el, n).ToArray());
            Assert.That(index, Is.InRange(0, n));
        }
    }
}
