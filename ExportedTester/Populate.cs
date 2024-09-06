using school_ad_v24.export;

namespace ExportedTester
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(24, 0, 0)]
        [TestCase(24, 0, 100)]
        public void CanPopulateIntArray(int length, int min, int max)
        {
            int[] array = Arrays.Populate(length, min, max);

            Assert.Multiple(() =>
            {
                Assert.That(array, Has.Length.EqualTo(length));
                Assert.That(Array.TrueForAll(array, el => {
                    bool minEqualToMax = min == max;
                    if (minEqualToMax) return el == min;

                    return el >= min && el < max;
                }), Is.True);
            });
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(24, 0, 0)]
        [TestCase(24, 0, 100)]
        public void CanPopulateDoubleArray(int length, double min, double max)
        {
            double[] array = Arrays.Populate(length, min, max);

            Assert.Multiple(() =>
            {
                Assert.That(array, Has.Length.EqualTo(length));
                Assert.That(Array.TrueForAll(array, el => {
                    bool minEqualToMax = min == max;
                    if (minEqualToMax) return el == min;

                    return el >= min && el < max;
                }), Is.True);
            });
        }
    }
}