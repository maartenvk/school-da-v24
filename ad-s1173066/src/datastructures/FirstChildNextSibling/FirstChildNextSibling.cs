using System;

namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public FirstChildNextSiblingNode<T> root;

        public IFirstChildNextSiblingNode<T> GetRoot()
        {
            return root;
        }

        private int SizeRecursive(FirstChildNextSiblingNode<T> node)
        {
            int totalSize = 1;

            if (node.hasChild())
            {
                totalSize += SizeRecursive(node.GetFirstChild());
            }

            if (node.hasNextSibling())
            {
                totalSize += SizeRecursive(node.GetNextSibling());
            }

            return totalSize;
        }

        public int Size()
        {
            if (root == null)
            {
                return 0;
            }

            return SizeRecursive(root);
        }

        public void PrintPreOrder()
        {
            Console.WriteLine(ToString());
        }

        private string ToStringRecursive(FirstChildNextSiblingNode<T> node)
        {
            string output = $"{node.GetData()}";

            if (node.hasChild())
            {
                string childOutput = ToStringRecursive(node.GetFirstChild());
                output += $",FC({childOutput})";
            }

            if (node.hasNextSibling())
            {
                string siblingOutput = ToStringRecursive(node.GetNextSibling());
                output += $",NS({siblingOutput})";
            }

            return output;
        }

        public override string ToString()
        {
            if (Size() == 0)
            {
                return "NIL";
            }

            return ToStringRecursive(root);
        }
    }
}
