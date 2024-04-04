namespace Fitzgerald_Code_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // initialize variables
            bool wantTranslate = true;
            string confirm = "";
            string transLang = "";

            // introductory text
            Console.WriteLine("----------------------------------\n-----ROMAN NVMERAL TRANSLATOR-----\n----------------------------------\n");

            do
            {
                // get language
                Console.WriteLine("Would you like to translate to decimal (d) or to Roman Numeral(r)");
                transLang = Console.ReadLine();

                //choose language
                if (transLang.ToUpper().Substring(0, 1) == "R")
                {
                    Decimal.ToRoman();
                }
                else if (transLang.ToUpper().Substring (0, 1) == "D")
                {
                    Roman.ToDecimal();
                }


                Console.WriteLine("\nWould you like to switch modes? (y/N)");
                confirm = Console.ReadLine();
                if (confirm.ToUpper().Substring(0, 1) != "Y")
                {
                    wantTranslate = false;
                }
            } while (wantTranslate);
            

            //Sign off
            Console.WriteLine("\nThank you, come again soon!");

        }
    }
}
