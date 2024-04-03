namespace Fitzgerald_Code_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //initialize needed variables
            string inputNums = "";
            int decimalValue = 0;
            List<char> charList = new List<char>();
            List<int> rawNums = new List<int>();
            bool convertNum = true;
            string confirm = "";

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
                // get the needed values
                Console.WriteLine("Please enter the Roman numeral:");
                inputNums = Console.ReadLine().ToUpper();

                // convert the string we just got to a char array and then a list for easier manipulation
                char[] romanNums = inputNums.ToCharArray();
                charList.AddRange(romanNums);


                // cleaning and verificiation
                for (var i = 0; i < charList.Count(); i++)
                {
                    if (charList[i] == 32)
                    {
                        charList.RemoveAt(i);
                    }
                }

                // Phase 1: Cycle through each element of the char array and just simply add it to the decimalValue variable. 
                // Phase 2: Add the values to an list of ints that can be summed together later. This allows me to look at the individual numbers
                for (var i = 0; i < charList.Count(); i++) 
                {
                    rawNums.Add(translationDict[charList[i]]); 
                }

                //This prevents an error in the next for loop
                rawNums.Add(0);

                //This is an attempt at subtraction
                for (var i = 0; i < rawNums.Count() - 1; i++)
                {
                    if (rawNums[i] < rawNums[i + 1])
                    {
                        rawNums[i] = rawNums[i + 1] - rawNums[i];
                        rawNums.RemoveAt(i + 1);
                    }
                }
            
                decimalValue = rawNums.Sum(x => x);

                // Print the final answer
                Console.WriteLine(inputNums + " = " + decimalValue);

                Console.WriteLine("\nWould you like to enter another number? (y/N)");
                confirm = Console.ReadLine();
                if (confirm.ToUpper().Substring(0,1) != "Y")
                {
                    convertNum = false;
                }
            }
            while (convertNum);

            

        }
    }
}
