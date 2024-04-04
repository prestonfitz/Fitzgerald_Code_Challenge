using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzgerald_Code_Challenge
{
    internal class Decimal
    {
        public static void ToRoman()
        {
            string inputNum = "";
            int startingInt = 0;
            bool validNum = true;
            bool convertNum = true;
            string confirm = "";
            string romNumeral = "";

            // start loop here as long as a user wants to convert numbers
            do
            {
                // reset necessary variables
                validNum = true;
                romNumeral = "";

                // get the needed values
                Console.WriteLine("\nPlease enter the decimal number:");
                inputNum = Console.ReadLine();    

                // convert or catch error
                try
                {
                    startingInt = Convert.ToInt32(inputNum);
                }
                catch (Exception e)
                {
                    validNum = false;
                }

                // number must be in range
                if ((startingInt > 3999) | (startingInt < 1))
                {
                    validNum = false ;
                }

                if (validNum)
                {

                    // convert to numeral
                    romNumeral = MyFunctions.calcNumeral(startingInt);

                    //print results
                    Console.WriteLine("\n" + inputNum + " = " + romNumeral);
                }
                else
                {
                    Console.WriteLine("\n" + inputNum + " is not a valid number; please enter a whole number between 1 and 3999");
                }

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
