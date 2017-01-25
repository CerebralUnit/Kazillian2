using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazillian.Model
{
    public static class ByteConverter
    {
        public static string ToString(byte[] bytes)
        {
            return BitConverter.ToString(bytes);
        }
        public static byte[] FromString(string str)
        { 
            byte[] bytes = str.Split('-')
                .Select(x => byte.Parse(x, NumberStyles.HexNumber))
                .ToArray();

            return bytes;
        }
    }
}
