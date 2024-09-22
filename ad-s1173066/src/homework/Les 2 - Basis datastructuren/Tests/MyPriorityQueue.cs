using NUnit.Framework;


namespace AD
{
    [TestFixture]
    public partial class MyPriorityQueueTests
    {
        [Test]
        public void MyPriorityQueue_1_Constructor_1_IsEmptyReturnsTrue()
        {
            // Arrange
            IMyPriorityQueue<string> q = DSBuilder.CreateMyPriorityQueueStringEmpty();
            bool expected = true;

            // Act
            bool actual = q.IsEmpty();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyPriorityQueue_2_Enqueue_1_IsEmptyReturnsFalse()
        {
            // Arrange
            IMyPriorityQueue<string> queue = DSBuilder.CreateMyPriorityQueueStringEmpty();
            bool expected = false;

            // Act
            queue.Enqueue("a");
            bool actual = queue.IsEmpty();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyPriorityQueue_2_Enqueue_2_GetFrontIsOkAfter1Enqueue()
        {
            // Arrange
            IMyPriorityQueue<string> queue = DSBuilder.CreateMyPriorityQueueStringEmpty();
            string expected = "a";

            // Act
            queue.Enqueue("a");
            string actual = queue.GetFront();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyPriorityQueue_2_Enqueue_3_GetFrontIsOkAfter3Enqueue()
        {
            // Arrange
            IMyPriorityQueue<string> queue = DSBuilder.CreateMyPriorityQueueStringEmpty();
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
        public void MyPriorityQueue_2_Enqueue_4_DequeueIsOkAfter1Enqueue()
        {
            // Arrange
            IMyPriorityQueue<string> queue = DSBuilder.CreateMyPriorityQueueStringEmpty();
            string expected = "a";

            // Act
            queue.Enqueue("a");
            string actual = queue.Dequeue();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyPriorityQueue_2_Enqueue_5_DequeueIsOkAfter3Enqueue()
        {
            // Arrange
            IMyPriorityQueue<string> queue = DSBuilder.CreateMyPriorityQueueStringEmpty();
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
        public void MyPriorityQueue_2_Enqueue_6_TwoTimesDequeueIsOkAfter3Enqueue()
        {
            // Arrange
            IMyPriorityQueue<string> queue = DSBuilder.CreateMyPriorityQueueStringEmpty();
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
        public void MyPriorityQueue_2_Enqueue_7_PrioritizesAfter3Enqueue()
        {
            // Arrange
            IMyPriorityQueue<string> queue = DSBuilder.CreateMyPriorityQueueStringEmpty();
            string expected = "d";

            // Act
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");
            queue.Enqueue("d", 5);
            string actual = queue.Dequeue();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyPriorityQueue_2_Enqueue_8_PrioritizesIntoExpectedPattern()
        {
            // Arrange
            IMyPriorityQueue<string> queue = DSBuilder.CreateMyPriorityQueueStringEmpty();
            string expected = "[(d,5),(b,3),(a,2),(c,1)]";

            // Act
            queue.Enqueue("a", 2);
            queue.Enqueue("b", 3);
            queue.Enqueue("c", 1);
            queue.Enqueue("d", 5);
            string actual = queue.ToString()!;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyPriorityQueue_3_GetFront_1_ThrowsExceptionOnEmptyStack()
        {
            // Arrange
            IMyPriorityQueue<string> queue = DSBuilder.CreateMyPriorityQueueStringEmpty();

            // Act & Assert
            Assert.Throws(typeof(MyPriorityQueueEmptyException), () => queue.GetFront());
        }

        [Test]
        public void MyPriorityQueue_3_GetFront_2_IsEmptyReturnsFalseAfterGetFrontOnOneElement()
        {
            // Arrange
            IMyPriorityQueue<string> queue = DSBuilder.CreateMyPriorityQueueStringEmpty();
            bool expected = false;

            // Act
            queue.Enqueue("a");
            queue.GetFront();
            bool actual = queue.IsEmpty();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyPriorityQueue_4_Dequeue_1_ThrowsExceptionOnEmptyList()
        {
            // Arrange
            IMyPriorityQueue<string> queue = DSBuilder.CreateMyPriorityQueueStringEmpty();

            // Act & Assert
            Assert.Throws(typeof(MyPriorityQueueEmptyException), () => queue.Dequeue());
        }

        [Test]
        public void MyPriorityQueue_4_Dequeue_2_IsEmptyReturnsTrueAfterGetFrontOnOneElement()
        {
            // Arrange
            IMyPriorityQueue<string> queue = DSBuilder.CreateMyPriorityQueueStringEmpty();
            bool expected = true;

            // Act
            queue.Enqueue("a");
            queue.Dequeue();
            bool actual = queue.IsEmpty();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}