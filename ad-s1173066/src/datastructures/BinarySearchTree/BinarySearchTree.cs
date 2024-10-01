using System.Text;
using System;

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

        public (BinaryNode<T>, BinaryNode<T>) FindWithParent(T x)
        {
            BinaryNode<T> node = GetRoot(), parent = GetRoot();

            while (node is not null)
            {
                int comparison = x.CompareTo(node.GetData());
                if (comparison == 0)
                {
                    return (node, parent);
                }

                parent = node;
                if (comparison < 0)
                {
                    node = node.GetLeft();
                    continue;
                }

                if (comparison > 0)
                {
                    node = node.GetRight();
                }
            }

            throw new BinarySearchTreeElementNotFoundException();
        }

        public void Remove(T x)
        {
            (BinaryNode<T> node, BinaryNode<T> parent) = FindWithParent(x);

            if (node.IsLeaf())
            {
                RemoveLeaf(node, parent);
                return;
            }

            if (node.HasLeft() ^ node.HasRight())
            {
                RemoveSingleChild(node, parent);
                return;
            }

            RemoveWithTwoChildren(node, parent);
        }

        public void RemoveLeaf(BinaryNode<T> node, BinaryNode<T> parent)
        {
            if (parent.right == node)
            {
                parent.right = null;
            }
            else
            {
                parent.left = null;
            }

            if (GetRoot() == node)
            {
                root = null;
            }
        }

        public void RemoveSingleChild(BinaryNode<T> node, BinaryNode<T> parent)
        {
            BinaryNode<T> child = node.GetLeft() ?? node.GetRight();
            if (parent.right == node)
            {
                parent.right = child;
            }
            else
            {
                parent.left = child;
            }
        }

        public void RemoveWithTwoChildren(BinaryNode<T> node, BinaryNode<T> parent)
        {
            BinaryNode<T> successor_parent = node;
            BinaryNode<T> successor = node.GetRight();
            while (successor.HasLeft())
            {
                successor_parent = successor;
                successor = successor.GetLeft();
            }

            BinaryNode<T> successor_successor = successor.GetRight();
            if (successor_parent.left == successor)
            {
                successor_parent.left = successor_successor;
            }
            else
            {
                successor_parent.right = successor_successor;
            }

            if (parent == node)
            {
                root = successor;
            }
            else if (parent.right == node)
            {
                parent.right = successor;
            }
            else
            {
                parent.left = successor;
            }

            successor.left = node.GetLeft();
            successor.right = node.GetRight();
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
