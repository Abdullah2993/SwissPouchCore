using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissPouchCore.Extensions
{
    public static class Extensions
    {
        public static byte[] ToBytes(this string str, Encoding encoding = null)
        {
            return encoding?.GetBytes(str) ?? Encoding.UTF8.GetBytes(str);
        }

        public static string ToHex(this byte[] bytes)
        {
            return BitConverter.ToString(bytes);
        }
    }
}
