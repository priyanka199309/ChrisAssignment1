using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace assignment1encoding
{
    public class conversions
    {
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
        public string BinaryToStringConversion(string binaryValue)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < binaryValue.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(binaryValue.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

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
