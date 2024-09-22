using System;

namespace AD
{
    public partial class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------

        public BinaryTree() { root = null; }

        public BinaryTree(T rootItem) : this()
        {
            root = new(rootItem);
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public BinaryNode<T> GetRoot()
        {
            return root;
        }

        private int SizeRecursive(BinaryNode<T> node)
        {
            int size = 1;

            if (node.HasLeft())
            {
                size += SizeRecursive(node.GetLeft());
            }

            if (node.HasRight())
            {
                size += SizeRecursive(node.GetRight());
            }

            return size;
        }

        public int Size()
        {
            if (IsEmpty())
            {
                return 0;
            }

            return SizeRecursive(root);
        }

        private int HeightRecursive(BinaryNode<T> node, int height)
        {
            int finalHeight = height;

            if (node.HasLeft())
            {
                int leftHeight = HeightRecursive(node.GetLeft(), height + 1);
                finalHeight = Math.Max(finalHeight, leftHeight);
            }

            if (node.HasRight())
            {
                int rightHeight = HeightRecursive(node.GetRight(), height + 1);
                finalHeight = Math.Max(finalHeight, rightHeight);
            }

            return finalHeight;
        }

        public int Height()
        {
            if (IsEmpty())
            {
                return -1;
            }

            return HeightRecursive(root, 0);
        }

        public void MakeEmpty()
        {
            root = null;
        }

        public bool IsEmpty()
        {
            return root is null;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            BinaryNode<T> rootLeft = t1 is null ? null : t1.GetRoot(),
                         rootRight = t2 is null ? null : t2.GetRoot();

            root = new(rootItem, rootLeft, rootRight);
        }

        private string ToPrefixStringRecursive(BinaryNode<T> node)
        {
            string output = "[ " + node.GetData().ToString() + ' ';

            if (node.HasLeft())
            {
                string leftOutput = ToPrefixStringRecursive(node.GetLeft());
                output += leftOutput + ' ';
            }
            else
            {
                output += "NIL ";
            }

            if (node.HasRight())
            {
                string rightOutput = ToPrefixStringRecursive(node.GetRight());
                output += rightOutput + ' ';
            }
            else
            {
                output += "NIL ";
            }

            output += ']';
            return output;
        }

        public string ToPrefixString()
        {
            if (IsEmpty())
            {
                return "NIL";
            }

            return ToPrefixStringRecursive(root);
        }

        private string ToInfixStringRecursive(BinaryNode<T> node)
        {
            string output = "[ ";
            if (node.HasLeft())
            {
                string leftOutput = ToInfixStringRecursive(node.GetLeft());
                output += leftOutput + ' ';
            }
            else
            {
                output += "NIL ";
            }

            output += node.GetData().ToString() + ' ';

            if (node.HasRight())
            {
                string rightOutput = ToInfixStringRecursive(node.GetRight());
                output += rightOutput + ' ';
            }
            else
            {
                output += "NIL ";
            }

            output += ']';
            return output;
        }

        public string ToInfixString()
        {
            if (IsEmpty())
            {
                return "NIL";
            }

            return ToInfixStringRecursive(root);
        }

        private string ToPostfixStringRecursive(BinaryNode<T> node)
        {
            string output = "[ ";
            if (node.HasLeft())
            {
                string leftOutput = ToPostfixStringRecursive(node.GetLeft());
                output += leftOutput + ' ';
            }
            else
            {
                output += "NIL ";
            }

            if (node.HasRight())
            {
                string rightOutput = ToPostfixStringRecursive(node.GetRight());
                output += rightOutput + ' ';
            }
            else
            {
                output += "NIL ";
            }

            output += node.GetData().ToString() + ' ';

            output += ']';
            return output;
        }

        public string ToPostfixString()
        {
            if (IsEmpty())
            {
                return "NIL";
            }

            return ToPostfixStringRecursive(root);
        }

        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        private int NumberOfLeavesRecursive(BinaryNode<T> node)
        {
            if (node.IsLeaf())
            {
                return 1;
            }

            int totalLeaves = 0;
            if (node.HasLeft())
            {
                totalLeaves += NumberOfLeavesRecursive(node.GetLeft());
            }

            if (node.HasRight())
            {
                totalLeaves += NumberOfLeavesRecursive(node.GetRight());
            }

            return totalLeaves;
        }

        public int NumberOfLeaves()
        {
            if (IsEmpty())
            {
                return 0;
            }

            return NumberOfLeavesRecursive(root);
        }

        private int NumberOfNodesWithOneChildRecursive(BinaryNode<T> node)
        {
            int total = 0;
            if (node.HasLeft() ^ node.HasRight())
            {
                total += 1;
            }

            if (node.HasLeft())
            {
                total += NumberOfNodesWithOneChildRecursive(node.GetLeft());
            }

            if (node.HasRight())
            {
                total += NumberOfNodesWithOneChildRecursive(node.GetRight());
            }

            return total;
        }

        public int NumberOfNodesWithOneChild()
        {
            if (IsEmpty())
            {
                return 0;
            }

            return NumberOfNodesWithOneChildRecursive(root);
        }

        private int NumberOfNodesWithTwoChildrenRecursive(BinaryNode<T> node)
        {
            int total = 0;
            if (node.HasLeft() && node.HasRight())
            {
                total += 1;
            }

            if (node.HasLeft())
            {
                total += NumberOfNodesWithTwoChildrenRecursive(node.GetLeft());
            }

            if (node.HasRight())
            {
                total += NumberOfNodesWithTwoChildrenRecursive(node.GetRight());
            }

            return total;
        }

        public int NumberOfNodesWithTwoChildren()
        {
            if (IsEmpty())
            {
                return 0;
            }

            return NumberOfNodesWithTwoChildrenRecursive(root);
        }
    }
}
