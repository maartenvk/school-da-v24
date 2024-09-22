using AD.MyQueue;

namespace AD
{
    //
    // This class offers static methods to create datastructures.
    // It is called by unit tests.
    //
    public partial class DSBuilder
    {
        public static IMyPriorityQueue<string> CreateMyPriorityQueueStringEmpty()
        {
            return new MyPriorityQueue<string>();
        }
        public static IMyPriorityQueue<int> CreateMyPriorityQueueIntEmpty()
        {
            return new MyPriorityQueue<int>();
        }
    }
}
