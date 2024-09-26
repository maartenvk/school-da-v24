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

        public int SizeRecursive(BinaryNode<T> node)
        {
            if (node is null)
            {
                return 0;
            }

            return 1 + SizeRecursive(node.GetLeft()) + SizeRecursive(node.GetRight());
        }

        public int Size()
        {
            return SizeRecursive(GetRoot());
        }

        public int HeightRecursive(BinaryNode<T> node, int height)
        {
            if (node is null)
            {
                return -1;
            }

            return Math.Max(height, Math.Max(
                HeightRecursive(node.GetLeft(), height + 1),
                HeightRecursive(node.GetRight(), height + 1)
            ));
        }

        public int Height()
        {
            return HeightRecursive(GetRoot(), 0);
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
            BinaryNode<T> left = null, right = null;

            if (t1 is not null)
            {
                left = t1.GetRoot();
            }

            if (t2 is not null)
            {
                right = t2.GetRoot();
            }

            root = new(rootItem, left, right);
        }

        public string ToPrefixStringRecursive(BinaryNode<T> node)
        {
            if (node is null)
            {
                return "NIL";
            }

            string left = ToPrefixStringRecursive(node.GetLeft());
            string right = ToPrefixStringRecursive(node.GetRight());

            return $"[ {node.GetData()} {left} {right} ]";
        }

        public string ToPrefixString()
        {
            return ToPrefixStringRecursive(GetRoot());
        }

        public string ToInfixStringRecursive(BinaryNode<T> node)
        {
            if (node is null)
            {
                return "NIL";
            }

            string left = ToInfixStringRecursive(node.GetLeft());
            string right = ToInfixStringRecursive(node.GetRight());

            return $"[ {left} {node.GetData()} {right} ]";
        }

        public string ToInfixString()
        {
            return ToInfixStringRecursive(GetRoot());
        }

        public string ToPostfixStringRecursive(BinaryNode<T> node)
        {
            if (node is null)
            {
                return "NIL";
            }

            string left = ToPostfixStringRecursive(node.GetLeft());
            string right = ToPostfixStringRecursive(node.GetRight());

            return $"[ {left} {right} {node.GetData()} ]";
        }

        public string ToPostfixString()
        {
            return ToPostfixStringRecursive(GetRoot());
        }

        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves()
        {
            if (IsEmpty())
            {
                return 0;
            }

            return BinaryTreeWalker<T, int>.OperateOn(GetRoot(), (children, node) =>
            {
                if (node.IsLeaf())
                {
                    return 1;
                }

                return children.Item1 + children.Item2;
            });
        }

        public int NumberOfNodesWithOneChildRecursive(BinaryNode<T> node)
        {
            if (node is null)
            {
                return 0;
            }

            int singleChild = 0;
            if (node.HasLeft() ^ node.HasRight())
            {
                singleChild = 1;
            }

            int left = NumberOfNodesWithOneChildRecursive(node.GetLeft());
            int right = NumberOfNodesWithOneChildRecursive(node.GetRight());

            return singleChild + left + right;
        }

        public int NumberOfNodesWithOneChild()
        {
            return NumberOfNodesWithOneChildRecursive(GetRoot());
        }

        public int NumberOfNodesWithTwoChildrenRecursive(BinaryNode<T> node)
        {
            if (node is null)
            {
                return 0;
            }

            int twoChildren = 0;
            if (node.HasLeft() && node.HasRight())
            {
                twoChildren = 1;
            }

            int left = NumberOfNodesWithTwoChildrenRecursive(node.GetLeft());
            int right = NumberOfNodesWithTwoChildrenRecursive(node.GetRight());

            return twoChildren + left + right;
        }

        public int NumberOfNodesWithTwoChildren()
        {
            return NumberOfNodesWithTwoChildrenRecursive(GetRoot());
        }
    }
}
