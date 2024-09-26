using System.Text;

namespace AD
{
    public partial class BinarySearchTree<T> : BinaryTree<T>, IBinarySearchTree<T>
        where T : System.IComparable<T>
    {

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public void InsertRecursive(BinaryNode<T> node, T x)
        {
            int comparison = x.CompareTo(node.GetData());
            if (comparison == 0)
            {
                return; // equal
            }

            if (comparison < 0) // left
            {
                if (node.HasLeft())
                {
                    InsertRecursive(node.GetLeft(), x);
                }
                else
                {
                    node.left = new BinaryNode<T>(x);
                }
            }
            else // right
            {
                if (node.HasRight())
                {
                    InsertRecursive(node.GetRight(), x);
                }
                else
                {
                    node.right = new BinaryNode<T>(x);
                }
            }
        }

        public void Insert(T x)
        {
            if (IsEmpty())
            {
                root = new BinaryNode<T>(x);
                return;
            }

            InsertRecursive(GetRoot(), x);
        }

        public static BinaryNode<T> FindMinNode(BinaryNode<T> node)
        {
            if (node is null)
            {
                throw new BinarySearchTreeEmptyException();
            }

            while (node.HasLeft())
            {
                node = node.GetLeft();
            }

            return node;
        }

        public T FindMin()
        {
            return FindMinNode(GetRoot()).GetData();
        }

        public void RemoveMin()
        {
            Remove(FindMin());
        }

        public void Remove(T x)
        {
            throw new System.NotImplementedException();
        }

        public static string InOrderRecursive(BinaryNode<T> node)
        {
            if (node is null)
            {
                return "NIL";
            }

            StringBuilder sb = new();

            string left = InOrderRecursive(node.GetLeft());
            string right = InOrderRecursive(node.GetRight());

            if (left != "NIL")
            {
                sb.Append(left + ' ');
            }

            sb.Append(node.GetData().ToString());

            if (right != "NIL")
            {
                sb.Append(' ' + right);
            }

            return sb.ToString();
        }

        public string InOrder()
        {
            if (IsEmpty())
            {
                return "";
            }

            return InOrderRecursive(GetRoot());
        }

        public override string ToString()
        {
            return InOrder();
        }
    }
}
