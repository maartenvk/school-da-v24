namespace AD
{
    public partial class BinaryNode<T> : IBinaryNode<T>
    {
        public T data;
        public BinaryNode<T> left;
        public BinaryNode<T> right;

        public BinaryNode() : this(default(T)) { }

        public BinaryNode(T data) : this(data, null, null) { }

        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------
        public T GetData()
        {
            return data;
        }

        public BinaryNode<T> GetLeft()
        {
            return left;
        }

        public BinaryNode<T> GetRight()
        {
            return right;
        }

        public bool HasLeft()
        {
            return left is not null;
        }

        public bool HasRight()
        {
            return right is not null;
        }

        public bool IsLeaf()
        {
            return !HasLeft() && !HasRight();
        }
    }
}
