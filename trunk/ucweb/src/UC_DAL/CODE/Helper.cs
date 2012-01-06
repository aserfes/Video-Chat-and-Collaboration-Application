using System;

namespace UCENTRIK.DAL
{
    public class Helper
    {
        public static System.Nullable<Int32> ResolveEmptyInt(Int32 id)
        {
            System.Nullable<Int32> _id = null;
            if (id != 0)
                _id = id;

            return _id;
        }
    }
}
