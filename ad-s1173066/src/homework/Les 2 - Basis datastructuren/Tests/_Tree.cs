using NUnit.Framework;


namespace AD
{
    [TestFixture]
    public partial class _TreeTests
    {
        [Test]
        public void Tree_1_Constructor_1_IsEmptyReturnsTrue()
        {
            // Arrange
            AD._Tree.Tree<int> t = DSBuilder.Create_Tree();
            bool expected = true;

            // Act
            bool actual = t.Empty();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_2_Insert_1_IsEmptyReturnsFalse()
        {
            // Arrange
            AD._Tree.Tree<int> t = DSBuilder.Create_Tree();
            bool expected = false;

            // Act
            t.Insert(0);
            bool actual = t.Empty();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_3_Head_IsOkAfter1Insert()
        {
            // Arrange
            AD._Tree.Tree<int> t = DSBuilder.Create_Tree();
            int expected = 5;

            // Act
            t.Insert(5);
            int actual = t.Head().Data;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_3_Head_IsOkAfter3Insert()
        {
            // Arrange
            AD._Tree.Tree<int> t = DSBuilder.Create_Tree();
            int expected = 5;

            // Act
            t.Insert(5);
            t.Insert(4);
            t.Insert(6);
            int actual = t.Head().Data;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_4_Remove_IsOkAfterInsert()
        {
            // Arrange
            AD._Tree.Tree<int> t = DSBuilder.Create_Tree();
            int expected = 5;

            // Act
            t.Insert(5);
            t.Insert(3);
            int actual = t.Head().Data;
            t.Remove(actual);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_5_Remove_IsOkAfter3Insert()
        {
            // Arrange
            AD._Tree.Tree<int> t = DSBuilder.Create_Tree();
            int expected = 5;

            // Act
            t.Insert(5);
            t.Insert(4);
            t.Insert(6);
            int actual = t.Head().Data;
            t.Remove(actual);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_6_Remove_IsOkAfter3Insert()
        {
            // Arrange
            AD._Tree.Tree<int> t = DSBuilder.Create_Tree();
            int expected = 5;

            // Act
            t.Insert(4);
            t.Insert(5);
            t.Insert(3);
            t.Remove(4);
            int actual = t.Head().Data;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_7_Find_IsOkAfter3Insert()
        {
            // Arrange
            AD._Tree.Tree<int> t = DSBuilder.Create_Tree();

            // Act
            t.Insert(4);
            t.Insert(5);
            t.Insert(3);
            AD._Tree.Node<int>? node = t.Find(5);

            // Assert
            Assert.NotNull(node);
        }

        [Test]
        public void Tree_7_Find_IsThrowsAfterNotFound()
        {
            // Arrange
            AD._Tree.Tree<int> t = DSBuilder.Create_Tree();

            // Act
            t.Insert(4);
            t.Insert(5);
            t.Insert(3);
            AD._Tree.Node<int>? node = t.Find(1);

            // Assert
            Assert.Null(node);
        }

        [Test]
        public void Tree_8_Contains_IsOkAfterInsert()
        {
            // Arrange
            AD._Tree.Tree<int> t = DSBuilder.Create_Tree();
            bool expected = true;

            // Act
            t.Insert(4);
            t.Insert(5);
            t.Insert(3);
            bool actual = t.Contains(5);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_9_Contains_IsOkAfterInsert()
        {
            // Arrange
            AD._Tree.Tree<int> t = DSBuilder.Create_Tree();
            bool expected = false;

            // Act
            t.Insert(4);
            t.Insert(5);
            t.Insert(3);
            bool actual = t.Contains(1);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
