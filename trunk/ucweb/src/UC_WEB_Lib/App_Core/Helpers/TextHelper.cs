using System;
using System.Collections.Generic;
using System.Web;



namespace UCENTRIK.Helpers
{
    public class TextHelper
    {
        public static string Left(string str, Int32 num)
        {
            Int32 len = str.Length;
            if (num > len)
                num = len;


            string result = str.Substring(0, num);

            return result;
        }

        public static string Right(string str, Int32 num)
        {
            Int32 len = str.Length;
            Int32 pos = len - num;

            if (pos < 0)
                pos = 0;

            string result = str.Substring(pos);

            return result;
        }
    
    }


}
