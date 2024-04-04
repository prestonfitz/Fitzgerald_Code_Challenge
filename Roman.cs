using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzgerald_Code_Challenge
{
    internal class Roman
    {
        public static void ToDecimal()
        {
            //initialize needed variables
            string inputNums = "";
            int decimalValue = 0;
            List<char> charList = new List<char>();
            List<int> rawNums = new List<int>();
            bool convertNum = true;
            string confirm = "";
            bool validNum = true;

            // this is a dictionary to hold what each Roman numeral is in a decimal
            var translationDict = new Dictionary<char, int>()
            {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000
            };

            // start loop here as long as a user wants to convert numbers
            do
            {
                // reset necessary variables
                validNum = true;
                charList.Clear();
                rawNums.Clear();

                // get the needed values
                Console.WriteLine("\nPlease enter the Roman numeral:");
                inputNums = Console.ReadLine().ToUpper(); // uppercase is for consistency

                // convert the string we just got to a char array and then a list for easier manipulation
                char[] romanNums = inputNums.ToCharArray();
                charList.AddRange(romanNums);

                //remove spaces
                charList = MyFunctions.RemoveSpaces(charList);

                // ensures letters are roman numberals
                validNum = MyFunctions.letterInDict(charList, translationDict);

                // check point 1: letters are in fact numerals
                if (validNum)
                {
                    // convert letters into numbers
                    rawNums = MyFunctions.charToInt(charList, translationDict);

                    // The order on the next two methods may seem kind of backwards, but I know the other method is always correct, so it will see if that match
                    // at long last, translate to decimal
                    decimalValue = MyFunctions.calcDecimal(rawNums);

                    string conversionString = new string(romanNums);

                    // check if leading numbers are correct
                    validNum = MyFunctions.leadingNum(decimalValue, conversionString) ;

                    // checkpoint 2: leading number is valid
                    if (validNum)
                    { 
                        // Print the final answer
                        Console.WriteLine("\n" + inputNums + " = " + decimalValue);
                    }


                }
                // report on any errors
                if (!validNum)
                {
                    Console.WriteLine("\n" + inputNums + " is not a valid Roman numeral");
                };

                // See if the user wants to enter another numeral
                Console.WriteLine("\nWould you like to enter another number? (y/N)");
                confirm = Console.ReadLine();
                if (confirm.ToUpper().Substring(0, 1) != "Y")
                {
                    convertNum = false;
                }

                // Separate actions
                Console.WriteLine("----------------------------------");
            }
            while (convertNum);
        }
    }
}
