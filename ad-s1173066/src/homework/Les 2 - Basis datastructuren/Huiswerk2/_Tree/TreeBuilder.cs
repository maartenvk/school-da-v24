namespace AD
{
    //
    // This class offers static methods to create datastructures.
    // It is called by unit tests.
    //
    public partial class DSBuilder
    {
        public static _Tree.Tree<int> Create_Tree()
        {
            return new _Tree.Tree<int>();
        }
    }
}