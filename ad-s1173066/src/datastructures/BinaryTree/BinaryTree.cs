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

            return 1 + SizeRecursive(node.left) + SizeRecursive(node.right);
        }

        public int Size()
        {
            return SizeRecursive(root);
        }

        public int HeightRecursive(BinaryNode<T> node, int height)
        {
            if (node is null)
            {
                return -1;
            }

            return Math.Max(height, Math.Max(
                HeightRecursive(node.left, height + 1),
                HeightRecursive(node.right, height + 1)
            ));
        }

        public int Height()
        {
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

            string left = ToPrefixStringRecursive(node.left);
            string right = ToPrefixStringRecursive(node.right);

            return $"[ {node.GetData()} {left} {right} ]";
        }

        public string ToPrefixString()
        {
            return ToPrefixStringRecursive(root);
        }

        public string ToInfixStringRecursive(BinaryNode<T> node)
        {
            if (node is null)
            {
                return "NIL";
            }

            string left = ToInfixStringRecursive(node.left);
            string right = ToInfixStringRecursive(node.right);

            return $"[ {left} {node.GetData()} {right} ]";
        }

        public string ToInfixString()
        {
            return ToInfixStringRecursive(root);
        }

        public string ToPostfixStringRecursive(BinaryNode<T> node)
        {
            if (node is null)
            {
                return "NIL";
            }

            string left = ToPostfixStringRecursive(node.left);
            string right = ToPostfixStringRecursive(node.right);

            return $"[ {left} {right} {node.GetData()} ]";
        }

        public string ToPostfixString()
        {
            return ToPostfixStringRecursive(root);
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

            int left = NumberOfNodesWithOneChildRecursive(node.left);
            int right = NumberOfNodesWithOneChildRecursive(node.right);

            return singleChild + left + right;
        }

        public int NumberOfNodesWithOneChild()
        {
            return NumberOfNodesWithOneChildRecursive(root);
        }

        public int NumberOfNodesWithTwoChildren()
        {
            if (IsEmpty())
            {
                return 0;
            }

            return BinaryTreeWalker<T, int>.OperateOn(GetRoot(), (children, node) =>
            {
                int total = children.Item1 + children.Item2;
                if (node.HasLeft() && node.HasRight())
                {
                    return total + 1;
                }

                return total;
            });
        }
    }
}
