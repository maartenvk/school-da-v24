namespace AD
{
    //
    // This class offers static methods to create datastructures.
    // It is called by unit tests.
    //
    public partial class DSBuilder
    {
        public static AD.MyArrayListGeneric.IMyArrayListGeneric<int> CreateMyArrayListGenericInt5()
        {
            return new MyArrayListGeneric.MyArrayListGeneric<int>(5);
        }

        public static AD.MyArrayListGeneric.IMyArrayListGeneric<double> CreateMyArrayListGenericDouble5()
        {
            return new MyArrayListGeneric.MyArrayListGeneric<double>(5);
        }
    }
}
