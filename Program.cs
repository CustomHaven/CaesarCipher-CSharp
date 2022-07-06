// https://www.codecademy.com/courses/learn-c-sharp/projects/csharp-caesar-cipher
using System;
using System.Text.RegularExpressions;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        { // hello => khoor || zebra => cheud
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            /*
             challenge on Q14 done inside the Main method and instead of having 2 methods doing nearly the same thing I done 1 method doing both of the two things of encryption or decryptions
             */
            Console.WriteLine("Welcome to the Ceaser Cipher where you got two options.");
            string msgString;
            string result;
            bool game = true;
            while (game)
            {
                Console.Write("Encrypt? or Decrypt? ");
                string choice = Console.ReadLine().ToLower();
                if (choice == "encrypt")
                {
                    Console.Write("Type a secret message: ");
                    msgString = Console.ReadLine().ToLower();
                    result = Cryptic(alphabet, msgString);
                    Console.WriteLine(result);
                    game = false;
                }
                else if (choice == "decrypt")
                {
                    Console.Write("Type the secret: ");
                    msgString = Console.ReadLine().ToLower();
                    result = Cryptic(alphabet, msgString, -3);
                    Console.WriteLine(result);
                    game = false;
                }
                else
                {
                    Console.WriteLine("Please type what we are asking");
                }
            }


        }

        static string Cryptic(char[] theAlphabet, string message, int addOrSubtract = 3)
        {
            // Q14 look for special chars we are using regex
            Regex special = new Regex("[\\s\\d\\\"\\'/!£$%^&*\\(\\)_+\\][\\}\\{#~'@\\;\\:\\/\\.\\,`¬\\?<>]");
            // Q2
            char[] secretMessage = message.ToCharArray();

            // Q3
            char[] encryptedMessage = new char[secretMessage.Length];

            // Q4 - Q9
            for (int i = 0; i < secretMessage.Length; i++)
            {


                char letter = secretMessage[i];

                // Q14 if we have special char we jump over this iteration
                if (special.IsMatch("" + letter)) // quick converting type char to type string by using "" + char
                {
                    continue;
                }

                // if above if statement is not met we continue the work
                int indexAlpha = Array.IndexOf(theAlphabet, letter);
                int tempIndex = indexAlpha + addOrSubtract;
                if (tempIndex < 0)
                {
                    tempIndex = Math.Abs(theAlphabet.Length + tempIndex);
                }
                int newIndex = (tempIndex) % theAlphabet.Length;
                letter = theAlphabet[newIndex];

                encryptedMessage[i] = letter;
            }
            // Q10 - Q13 loads of test from q11 to q13
            string secretWord = String.Join("", encryptedMessage);
            return secretWord;
        }
    }
}