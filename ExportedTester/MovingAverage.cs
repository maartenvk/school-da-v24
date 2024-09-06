using school_ad_v24.export;

namespace ExportedTester
{
    public class MovingAverage
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new double[] { 4, 5, 3, 2, 1, 1, 4, 8, 10, 12, 15, 18, 20 }, 4, new double[] { 4, 4.5, 4, 3.5, 2.75, 1.75, 2, 3.5, 5.75, 8.5, 11.25, 13.75, 16.25 })]
        public void FindsAverage(double[] array, int n, double[] expected)
        {
            Assert.That(Arrays.MovingAverage(array, n), Is.EqualTo(expected));
        }
    }
}
