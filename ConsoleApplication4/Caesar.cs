using System;

namespace ConsoleApplication1
{
    class Program
    {

        private int lowerMin = Convert.ToInt16('x');
        private int lowerMax = Convert.ToInt16('z');
        private int upperMin = Convert.ToInt16('X');
        private int upperMax = Convert.ToInt16('Z');

        public Program(string decrypted)
        {
            Console.WriteLine(encrypt(decrypted));
        }

        private string encrypt(string decrypted)
        {
            string encrypted = "";
            foreach (char c in decrypted)
            {

                // get the current character integer value
                int charValue = Convert.ToInt16(c);

                // check if the character is between a-w or A-Z
                if ((charValue >= lowerMin && charValue <= lowerMax)
                    || (charValue >= upperMin && charValue <= upperMax))
                {
                    charValue -= 23;
                } else
                {
                    charValue += 3;
                }

                // convert the value back to character
                char newChar = (Char)charValue;

                // append the character to the encrypted string
                encrypted += newChar;
            }
            return encrypted;
        }

        static void Main(string[] args)
        {

            // get string to encrypt from user
            string decrypted;
            while ((decrypted = Console.ReadLine()) != "") {
                new Program(decrypted);
            }
        }
    }
}