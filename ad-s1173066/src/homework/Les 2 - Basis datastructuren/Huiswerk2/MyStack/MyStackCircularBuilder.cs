namespace AD
{
    //
    // This class offers static methods to create datastructures.
    // It is called by unit tests.
    //
    public partial class DSBuilder
    {
        public static IMyStack<string> CreateMyStackCircularStringEmpty5()
        {
            return new MyStack.MyStackCircular<string>(5);
        }
        public static IMyStack<int> CreateMyStackCircularIntEmpty5()
        {
            return new MyStack.MyStackCircular<int>(5);
        }
    }
}
