using AD.MyQueue;
using NUnit.Framework;


namespace AD
{
    [TestFixture]
    public partial class MyQueueCircularTests
    {
        [Test]
        public void MyQueue_1_Constructor_1_IsEmptyReturnsTrue()
        {
            // Arrange
            IMyQueue<string> q = DSBuilder.CreateMyQueueCircularString5();
            bool expected = true;

            // Act
            bool actual = q.IsEmpty();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyQueue_2_Enqueue_1_IsEmptyReturnsFalse()
        {
            // Arrange
            IMyQueue<string> queue = DSBuilder.CreateMyQueueCircularString5();
            bool expected = false;

            // Act
            queue.Enqueue("a");
            bool actual = queue.IsEmpty();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyQueue_2_Enqueue_2_GetFrontIsOkAfter1Enqueue()
        {
            // Arrange
            IMyQueue<string> queue = DSBuilder.CreateMyQueueCircularString5();
            string expected = "a";

            // Act
            queue.Enqueue("a");
            string actual = queue.GetFront();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyQueue_2_Enqueue_3_GetFrontIsOkAfter3Enqueue()
        {
            // Arrange
            IMyQueue<string> queue = DSBuilder.CreateMyQueueCircularString5();
            string expected = "a";

            // Act
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");
            string actual = queue.GetFront();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyQueue_2_Enqueue_4_DequeueIsOkAfter1Enqueue()
        {
            // Arrange
            IMyQueue<string> queue = DSBuilder.CreateMyQueueCircularString5();
            string expected = "a";

            // Act
            queue.Enqueue("a");
            string actual = queue.Dequeue();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyQueue_2_Enqueue_5_DequeueIsOkAfter3Enqueue()
        {
            // Arrange
            IMyQueue<string> queue = DSBuilder.CreateMyQueueCircularString5();
            string expected = "a";

            // Act
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");
            string actual = queue.Dequeue();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyQueue_2_Enqueue_6_TwoTimesDequeueIsOkAfter3Enqueue()
        {
            // Arrange
            IMyQueue<string> queue = DSBuilder.CreateMyQueueCircularString5();
            string expected = "b";

            // Act
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");
            queue.Dequeue();
            string actual = queue.Dequeue();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyQueue_3_GetFront_1_ThrowsExceptionOnEmptyStack()
        {
            // Arrange
            IMyQueue<string> queue = DSBuilder.CreateMyQueueCircularString5();

            // Act & Assert
            Assert.Throws(typeof(MyQueueEmptyException), () => queue.GetFront());
        }

        [Test]
        public void MyQueue_3_GetFront_2_IsEmptyReturnsFalseAfterGetFrontOnOneElement()
        {
            // Arrange
            IMyQueue<string> queue = DSBuilder.CreateMyQueueCircularString5();
            bool expected = false;

            // Act
            queue.Enqueue("a");
            queue.GetFront();
            bool actual = queue.IsEmpty();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyQueue_4_Dequeue_1_ThrowsExceptionOnEmptyList()
        {
            // Arrange
            IMyQueue<string> queue = DSBuilder.CreateMyQueueCircularString5();

            // Act & Assert
            Assert.Throws(typeof(MyQueueEmptyException), () => queue.Dequeue());
        }

        [Test]
        public void MyQueue_4_Dequeue_2_IsEmptyReturnsTrueAfterGetFrontOnOneElement()
        {
            // Arrange
            IMyQueue<string> queue = DSBuilder.CreateMyQueueCircularString5();
            bool expected = true;

            // Act
            queue.Enqueue("a");
            queue.Dequeue();
            bool actual = queue.IsEmpty();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyQueue_5_Enqueue_1_ThrowsExceptionOnFullList()
        {
            // Arrange
            IMyQueue<string> queue = DSBuilder.CreateMyQueueCircularString5();

            // Act
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");
            queue.Enqueue("d");
            queue.Enqueue("e");

            // Assert
            Assert.Throws(typeof(MyQueueFilledException), () => queue.Enqueue("Kaboom"));
        }

        [Test]
        public void MyQueue_6_Enqueue_1_DoesNotDoWeirdStuffOnFullBufferDequeueAndEnqueue()
        {
            // Arrange
            IMyQueue<string> queue = DSBuilder.CreateMyQueueCircularString5();
            string expected = "cdeZY";

            // Act
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");
            queue.Enqueue("d");
            queue.Enqueue("e");

            queue.Dequeue();
            queue.Enqueue("Z");
            queue.Dequeue();
            queue.Enqueue("Y");

            string actual = "";
            while (!queue.IsEmpty())
            {
                actual += queue.Dequeue();
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
