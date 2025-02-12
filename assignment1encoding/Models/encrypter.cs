﻿using System;
using System.Text;

namespace assignment1encoding.Models
{
    public class encrypter
    {
        public encrypter(string originalText, int[] encryptionCipher = null, int encryptionDepth=1 )
        {


            OriginalText = originalText;

            if (encryptionCipher != null)
            {
                if (EncryptionCipher != encryptionCipher)
                {
                    EncryptionCipher = encryptionCipher;
                }
            }

            if (EncryptionDepth != encryptionDepth)
            {
                EncryptionDepth = encryptionDepth;
            }

            ConvertText(OriginalText, EncryptionCipher, EncryptionDepth);
        }

        public void ConvertText(string originalText, int[] encryptionCipher = null, int encryptionDepth = 1)
        {
            CipherEncrypted = DeepEncryptWithCipher(OriginalText, EncryptionCipher, EncryptionDepth);

            //Convert Original Text to other base formats
            Base64 = StringToBase64(OriginalText);
            Binary = StringToBinary(OriginalText);
            Hexadecimal = StringToHex(OriginalText);
        }

        public string OriginalText { get; internal set; }
        public int[] EncryptionCipher { get; } = new[] { 1, 1, 2, 3, 5, 8 }; //Fibonacci Sequence
        public int EncryptionDepth { get; } = 1;
        public string CipherEncrypted { get; internal set; }
        public string Base64 { get; internal set; }
        public string Binary { get; internal set; }
        public string Hexadecimal { get; internal set; }

        public static string DeepEncryptWithCipher(string originalText, int[] encryptionCipher, int encryptionDepth)
        {
            string result = originalText;

      

            //Encrypt result encryptionDepth times
            for (int depth = 0; depth < encryptionDepth; depth++)
            {
                //Apply Encryption Cipher on current value of result
                result = EncryptWithCipher(result, encryptionCipher);

                //Add new encrypted result to the encrypted array fro demonstration
                //encryptedValues[depth + 1] = result;
            }

            return result;
        }

       
        public static string EncryptWithCipher(string text, int[] encryptionCipher)
        {
            if (encryptionCipher == null || encryptionCipher.Length == 0)
            {
                return text;
            }

            //Store the original string converted to bytes
            //Convert the text data to Unicode byte in order to handle non ASCII value character
            byte[] bytearray = Encoding.Unicode.GetBytes(text);

            //Build byte array from the original byte array that will receive the encrypted values
            byte[] bytearrayresult = bytearray;

            int encryptionCipherIndex = 0;

            //Apply Encryption Cipher
            for (int i = 0; i < bytearray.Length; i++)
            {
                //Set the Cipher index
                encryptionCipherIndex = i;

                //We reset the current encryption position to 0 to restart at the beginning of the encryptionCipher
                if (encryptionCipherIndex >= encryptionCipher.Length)
                {
                    //Reset the cryper postion to zero and restart sequence
                    encryptionCipherIndex = 0;
                }

              
                if (bytearray[i] != 0)
                {
                    bytearrayresult[i] = (byte)(bytearray[i] + encryptionCipher[encryptionCipherIndex]);
                }
            }

            string newresult = Encoding.Unicode.GetString(bytearrayresult);

            return newresult;
        }

   
        public static string DeepDecryptWithCipher(string originalText, int[] encryptionCipher, int encryptionDepth)
        {
            string result = originalText;

            //For demonstration
            string[] encryptedValues = new string[encryptionDepth + 1];
            encryptedValues[0] = result;

            //Encrypt result encryptionDepth times
            for (int depth = 0; depth < encryptionDepth; depth++)
            {
                //Apply Encryption Cipher on current value of result
                result = DecryptWithCipher(result, encryptionCipher);

                //Add new encrypted result to the encrypted array fro demonstration
                encryptedValues[depth + 1] = result;
            }

            return result;
        }

        
        public static string DecryptWithCipher(string text, int[] encryptionCipher)
        {
            //Convert the text data to Unicode byte in order to handle non ASCII value character
            byte[] bytearray = Encoding.Unicode.GetBytes(text);
            //Build byte array from the original byte array that will receive the encrypted values
            byte[] bytearrayresult = bytearray;

            int encryptionCipherIndex = 0;

            for (int i = 0; i < bytearray.Length; i++)
            {
                //Set the Cipher index
                encryptionCipherIndex = i;

                //We reset the current encryption position to 0 to restart at the beginning of the encryptionCipher
                if (encryptionCipherIndex >= encryptionCipher.Length)
                {
                    //Reset the cryper postion to zero and restart sequence
                    encryptionCipherIndex = 0;
                }

                if (bytearray[i] != 0)
                {
                    bytearrayresult[i] = (byte)(bytearray[i] - encryptionCipher[encryptionCipherIndex]);
                }
            }

            string newresult = Encoding.Unicode.GetString(bytearrayresult);

            return newresult;
        }

   
        public static string Base64ToString(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return String.Empty;
            }

            byte[] bytearray = Convert.FromBase64String(data);

            return Encoding.Unicode.GetString(bytearray);
        }

        public static string StringToBase64(string data)
        {
            byte[] bytearray = Encoding.Unicode.GetBytes(data);

            return Convert.ToBase64String(bytearray);
        }

     
     
        public static string StringToHex(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                //Convert the char to base 16 and pad the output with 0
                sb.Append(Convert.ToString(c, 16).PadLeft(2, '0') + " ");
            }

            return sb.ToString().ToUpper();
        }

      
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                //Convert the char to base 2 and pad the output with 0
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0') + " ");
            }
            return sb.ToString();
        }





    }
}

