using System;
using System.Text;

namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public FirstChildNextSiblingNode<T> root;

        public IFirstChildNextSiblingNode<T> GetRoot()
        {
            return root;
        }

        public static int SizeRecursive(IFirstChildNextSiblingNode<T> node)
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

        public static string PreOrderStringRecursive(IFirstChildNextSiblingNode<T> node, int depth)
        {
            if (node is null)
            {
                return "";
            }

            StringBuilder sb = new(new String('\t', depth));
            sb.Append(node.GetData().ToString());

            string childStr = PreOrderStringRecursive(node.GetFirstChild(), depth + 1);
            string siblingStr = PreOrderStringRecursive(node.GetNextSibling(), depth);

            if (childStr != "")
            {
                sb.Append('\n');
                sb.Append(childStr);
            }

            if (siblingStr != "")
            {
                sb.Append('\n');
                sb.Append(siblingStr);
            }

            return sb.ToString();
        }

        public void PrintPreOrder()
        {
            Console.WriteLine(PreOrderStringRecursive(GetRoot(), 0));
        }

        public static string ToStringRecursive(IFirstChildNextSiblingNode<T> node)
        {
            if (node is null)
            {
                return "NIL";
            }

            StringBuilder sb = new(node.GetData().ToString());

            string childOutput = ToStringRecursive(node.GetFirstChild());
            string siblingOutput = ToStringRecursive(node.GetNextSibling());

            if (childOutput != "NIL")
            {
                sb.Append($",FC({childOutput})");
            }

            if (siblingOutput != "NIL")
            {
                sb.Append($",NS({siblingOutput})");
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringRecursive(GetRoot());
        }
    }
}
