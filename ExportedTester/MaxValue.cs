using school_ad_v24.export;

namespace ExportedTester
{
    public class MaxValue
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 6)]
        [TestCase(new int[] { 7, 2, 3, 4, 5, 6 }, 7)]
        [TestCase(new int[] { 7, 2, 8, 4, 5, 6 }, 8)]
        public void FindsInt(int[] array, int expected)
        {
            Assert.That(Arrays.MaxValue(array), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new double[] { 1, 2, 3, 4, 5, 6 }, 6)]
        [TestCase(new double[] { 7, 2, 3, 4, 5, 6 }, 7)]
        [TestCase(new double[] { 7, 2, 8, 4, 5, 6 }, 8)]
        public void FindsDouble(double[] array, double expected)
        {
            Assert.That(Arrays.MaxValue(array), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1, 64)]
        [TestCase(5, 32)]
        public void FindsEqual(int el, int n)
        {
            Assert.That(Arrays.MaxValue(Enumerable.Repeat(el, n).ToArray()), Is.EqualTo(el));
        }

        [Test]
        public void InvalidOnEmpty()
        {
            Assert.Throws<ArgumentException>(() => Arrays.MaxValue(Array.Empty<int>()));
        }
    }
}
