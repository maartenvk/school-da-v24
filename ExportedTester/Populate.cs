using school_ad_v24.export;
using System.Diagnostics;

namespace ExportedTester
{
    public class Populate
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

        [Test]
        public void InvalidLengthThrows()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Arrays.Populate(-1, 0, 0));
        }
    }
}