using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzgerald_Code_Challenge
{
    internal class MyFunctions
    {
        public static List<char> RemoveSpaces(List<char> list)
        {
            for (var character = 0; character < list.Count(); character++)
            {
                // remove spaces. I am removing them rather than throwing an error in case someone has leading or trailing spaces. The downside is that if someone decides to try and enter a list of Roman numberals this way, it will assume they are all in one numeral
                if (list[character] == 32)
                {
                    list.RemoveAt(character);
                }

                
            }
            return list;
        }

        public static bool letterInDict(List<char> list, Dictionary<char, int> dict)
        {
            bool validNum = true;

            for (var character = 0; character < list.Count(); character++)
            {
                // Check if letter is not in the dictionary
                if (!dict.ContainsKey(list[character]))
                {
                    validNum = false;
                }
            }

            return validNum;
        }

        public static List<int> charToInt(List<char> list, Dictionary<char, int> dict)
        {
            List<int> rawNums = new List<int>();

            // Phase 1: Cycle through each element of the char array and just simply add it to the decimalValue variable. 
            // Phase 2: Add the values to an list of ints that can be summed together later. This allows me to look at the individual numbers
            for (var character = 0; character < list.Count(); character++)
            {
                rawNums.Add(dict[list[character]]);
            }

            return rawNums;
        }

        public static bool leadingNum(int startingInt, string startingNumeral)
        {
            bool validNum = true;

            string properNumeral = calcNumeral(startingInt);

            // This checks if the leading number follows the rules
            if (properNumeral != startingNumeral)
            {
                validNum = false;
            }
            
            return validNum;
        }

        //Old test code, just in case I need it
        //public static bool leadingNum(List<int> list)
        //{
        //    bool validNum = true;

        //    for (var i = 0; i < list.Count() - 1; i++)
        //    {
        //        // This checks if the leading number follows the rules
        //        if ((list[i] * 10) < list[i + 1])
        //        {
        //            validNum = false;
        //        }
        //    }

        //    return validNum;
        //}
        public static int calcDecimal(List<int> list)
        {
            int decimalValue;

            //This prevents an error in the for loop
            list.Add(0);

            //This subtracts the two values if the one on the left is less than the one on the right
            for (var i = 0; i < list.Count() - 1; i++)
            {
                if (list[i] < list[i + 1])
                {
                    list[i] = list[i + 1] - list[i];
                    list.RemoveAt(i + 1);
                }
            }

            decimalValue = list.Sum(x => x);
            return decimalValue;
        }

        public static string calcNumeral(int startingInt)
        {
            string romNumeral = "";

            // This checks to see if the largest number can still be pulled out of whatever we have. If it can, it tacks that numeral on and then subtracts it so we can't do it again. It loops through each one that way.
            while ((startingInt - 1000) >= 0)
            {
                romNumeral += "M";
                startingInt -= 1000;
            }
            while ((startingInt - 900) >= 0)
            {
                romNumeral += "CM";
                startingInt -= 900;
            }
            while ((startingInt - 500) >= 0)
            {
                romNumeral += "D";
                startingInt -= 500;
            }
            while ((startingInt - 400) >= 0)
            {
                romNumeral += "CD";
                startingInt -= 400;
            }
            while ((startingInt - 100) >= 0)
            {
                romNumeral += "C";
                startingInt -= 100;
            }
            while ((startingInt - 90) >= 0)
            {
                romNumeral += "XC";
                startingInt -= 90;
            }
            while ((startingInt - 50) >= 0)
            {
                romNumeral += "L";
                startingInt -= 50;
            }
            while ((startingInt - 40) >= 0)
            {
                romNumeral += "XL";
                startingInt -= 40;
            }
            while ((startingInt - 10) >= 0)
            {
                romNumeral += "X";
                startingInt -= 10;
            }
            while ((startingInt - 9) >= 0)
            {
                romNumeral += "IX";
                startingInt -= 9;
            }
            while ((startingInt - 5) >= 0)
            {
                romNumeral += "V";
                startingInt -= 5;
            }
            while ((startingInt - 4) >= 0)
            {
                romNumeral += "IV";
                startingInt -= 4;
            }
            while ((startingInt - 1) >= 0)
            {
                romNumeral += "I";
                startingInt -= 1;
            }

            return romNumeral;
        }
    }
}
