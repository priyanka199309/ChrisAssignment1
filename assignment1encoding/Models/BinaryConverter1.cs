using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace assignment1encoding.Models
{
    public class BinaryConverter1
    {
        //String to binary
        public string StringToBinaryConversion(string data)
        {
            string convertedValue = string.Empty;
            // convert string to byte
            byte[] byteArray = Encoding.ASCII.GetBytes(data);


            for (int i = 0; i < byteArray.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    convertedValue += (byteArray[i] & 0x80) > 0 ? "1" : "0";
                    byteArray[i] <<= 1;
                }
            }

            return convertedValue;
        }
        //binary to string
        public string BinaryToStringConversion(string binaryValue)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < binaryValue.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(binaryValue.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        //string to hex
        public string StringToHex2(string hexString)
        {
            StringBuilder sb = new StringBuilder();

            byte[] bytearray = Encoding.ASCII.GetBytes(hexString);

            foreach (byte bytepart in bytearray)
            {
                sb.Append(bytepart.ToString("X2"));
            }

            return sb.ToString().ToUpper();
        }
        //hex to string
        public string HexToStringConversion(String hexValue)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexValue.Length; i += 2)
                {
                    String value = string.Empty;

                    value = hexValue.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(value, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }
        //string to base64

        public string StringToBase64Conversion(string StringValue)
        {
            byte[] bytearray = Encoding.ASCII.GetBytes(StringValue);

            string result = Convert.ToBase64String(bytearray);

            return result;
        }




        //Convert your Base64 encoded name back to ASCII

        public string Base64ToStringConversion(string base64String)
        {
            byte[] bytearray = Convert.FromBase64String(base64String);

            using (var ms = new MemoryStream(bytearray))
            {
                using (StreamReader reader = new StreamReader(ms))
                {
                    string text = reader.ReadToEnd();
                    return text;
                }
            }
        }

    }
}
