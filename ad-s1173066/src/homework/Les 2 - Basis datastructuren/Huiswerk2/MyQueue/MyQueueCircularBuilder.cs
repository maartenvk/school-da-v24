using AD.MyQueue;

namespace AD
{
    //
    // This class offers static methods to create datastructures.
    // It is called by unit tests.
    //
    public partial class DSBuilder
    {
        public static IMyQueue<string> CreateMyQueueCircularString5()
        {
            return new MyQueueCircular<string>(5);
        }
        public static IMyQueue<int> CreateMyQueueCircularInt5()
        {
            return new MyQueueCircular<int>(5);
        }
    }
}
