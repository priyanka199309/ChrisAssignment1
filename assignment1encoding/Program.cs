using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using assignment1encoding.Models;

namespace assignment1encoding
{
   public class Program
    {
        
        static void Main(string[] args)
        {

            int options;

            string testString;
            Console.Write("Enter any string:");
            testString = Console.ReadLine();
            //Create object of BinaryConverter1 class
            BinaryConverter1 binaryConverter1 = new BinaryConverter1();
            //String to Binary
            string binaryValue = binaryConverter1.StringToBinaryConversion(testString);
            Console.WriteLine($"{testString} as Binary: {binaryValue}");
            //Binary to string
            Console.WriteLine($"{testString} from Binary to ASCII: {binaryConverter1.BinaryToStringConversion(binaryValue)}");
            //string to hex
            string HexaValue = binaryConverter1.StringToHex2(testString);
            Console.WriteLine($"{testString} as HexaDecimal: {HexaValue}");
            //hex to ASCII
            Console.WriteLine($"{testString} from HexaDecimal to ASCII: {binaryConverter1.HexToStringConversion(HexaValue)}");
            //string to base64
            String base64 = binaryConverter1.StringToBase64Conversion(testString);
            Console.WriteLine($"{testString} as Base64: {base64}");
            //base64 to string
            Console.WriteLine($"{testString} from Base64 to String: {binaryConverter1.Base64ToStringConversion(base64)}");

            //Encryption descryption
            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 }; //Fibonacci Sequence
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display

            int encryptionDepth = 20;

            encrypter encrypter = new encrypter(testString, cipher, encryptionDepth);

            //Single Level Encrytion
            string nameEncryptWithCipher = encrypter.EncryptWithCipher(testString, cipher);
            Console.WriteLine($"Encrypted once using the cipher {{{cipherasString}}} {nameEncryptWithCipher}");

            string nameDecryptWithCipher = encrypter.DecryptWithCipher(nameEncryptWithCipher, cipher);
            Console.WriteLine($"Decrypted once using the cipher {{{cipherasString}}} {nameDecryptWithCipher}");

            //Deep Encrytion
            string nameDeepEncryptWithCipher = encrypter.DeepEncryptWithCipher(testString, cipher, encryptionDepth);
            Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");

            string nameDeepDecryptWithCipher = encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, cipher, encryptionDepth);
            Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");

            //Base64 Encoded
            Console.WriteLine($"Base64 encoded {testString} {encrypter.Base64}");

            string base64toPlainText = encrypter.Base64ToString(encrypter.Base64);
            Console.WriteLine($"Base64 decoded {encrypter.Base64} {base64toPlainText}");



            //Console.WriteLine("Choose your Option:\n");
            //Console.WriteLine("1.Convert string to binary: \n");
            //Console.WriteLine("2.Convert binary to Ascii: \n");
            //Console.WriteLine("3.Convert string to Hexadecimal: \n");
            //Console.WriteLine("4.Convert Hexadecimal to string: \n");
            //Console.WriteLine("5.Convert string to Base64: \n");

            //options = Convert.ToInt32(Console.ReadLine());
            //if(options==1)
            //{
            //    Console.Write("Enter any string:");
            //    testString = Console.ReadLine();
            // binaryValue = binaryConverter1.StringToBinaryConversion(testString);
            //    Console.WriteLine($"{testString} as Binary: {binaryValue}");
            //}
            //else if(options==2)
            //{
            //    Console.Write("Enter any Binary value:");
            //    testString = Console.ReadLine();
                
            //    string asciiValue = binaryConverter1.BinaryToStringConversion(testString);
            //    Console.WriteLine(asciiValue);
            //    //Console.WriteLine($"{testString} from Binary to ASCII: {asciiValue}");
            //}
            //else if (options == 3)
            //{

            //}
            //else if (options == 4)
            //{

            //}

            //else if (options == 5)
            //{

            //}




        }

    }
          
    
}

   


