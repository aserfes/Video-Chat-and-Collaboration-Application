using System;

namespace UCENTRIK.BLL
{
    public class Helper
    {

        public static string EncryptPasswords(string password)
        {
            return RijndaelEnhancedWrapper.EncryptString(password); ;
        }
        public static string DecryptPasswords(string password)
        {
            return RijndaelEnhancedWrapper.DecryptString(password); ;
        }




        public static string GetFullName(string firstName, string lastName)
        {
            if ((firstName == null) && (lastName == null))
                return null;
            else
                return firstName + " " + lastName;
        }


        public static string GetDuration(DateTime start, DateTime end)
        {
            TimeSpan span = end.Subtract(start);

            Int32 minutes = Convert.ToInt32(span.TotalMinutes);

            if (minutes > 0)
                return minutes.ToString();
            else
                return "";
        }



    }


}
