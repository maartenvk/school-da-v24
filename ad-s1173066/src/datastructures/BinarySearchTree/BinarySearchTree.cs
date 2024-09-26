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

        public T FindMin()

        {
            throw new System.NotImplementedException();
        }

        public void RemoveMin()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(T x)
        {
            throw new System.NotImplementedException();
        }

        public string InOrder()
        {
            throw new System.NotImplementedException();
        }
    }
}
