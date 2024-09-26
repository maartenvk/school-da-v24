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

        private int SizeRecursive(IFirstChildNextSiblingNode<T> node)
        {
            if (node is null)
            {
                return 0;
            }

            int firstChildSize = SizeRecursive(node.GetFirstChild());
            int nextSiblingSize = SizeRecursive(node.GetNextSibling());

            return 1 + firstChildSize + nextSiblingSize;
        }

        public int Size()
        {
            return SizeRecursive(GetRoot());
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
