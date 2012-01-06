using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCENTRIK.LIB.Functions
{
    public class TextFunctions
    {




        public static string FormatFreeText(string inText, Int32 maxWordLength)
        {
            string outText = "";

            inText = inText.Trim();
            inText = inText.Replace("  ", " ");

            string[] words = inText.Split(' ');
            foreach (string word in words)
            {
                outText = outText + CutOffLongText(word, maxWordLength) + " ";
            }

            return outText;
        }




        public static string FormatLineBreaks(string inText)
        {
            return inText.Replace("\n", "<br>");
        }



        //public static string CutOffLongText(string inText, Int32 maxLength)
        //{
        //    string outText = "";
        //    Int32 len = inText.Length;


        //    if (len > maxLength)
        //    {
        //        len = maxLength;

        //        string firstString = inText.Substring(0, len);
        //        string lastString = inText.Substring(maxLength, inText.Length - maxLength);
        //        lastString = CutOffLongText(lastString, maxLength);

        //        outText = firstString + " " + lastString;
        //    }
        //    else
        //    {
        //        outText = inText;
        //    }

        //    return outText;
        //}





        public static string CutOffLongText(string inText, Int32 maxLength)
        {
            string outText = "";
            Int32 len = inText.Length;

            if (len > maxLength)
            {
                string firstString = inText.Substring(0, maxLength);
                string lastString = inText.Substring(maxLength, len - maxLength);
                lastString = CutOffLongText(lastString, maxLength);

                outText = firstString + " " + lastString;
            }
            else
            {
                outText = inText;
            }

            return outText;
        }



        //---
    }







    //-
}
