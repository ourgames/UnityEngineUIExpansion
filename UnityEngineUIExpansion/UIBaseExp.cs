using System;
using System.Text;
namespace UnityEngineUIExpansion
{
    public class UIBaseExp
    {
        private static uint b00 = 0b01100010U;
        private static uint b01 = 0b01101100U;
        private static uint b02 = 0b01101001U;
        private static uint b03 = 0b01110100U;
        private static uint b04 = 0b01111010U;
        private static long c01 = 34672958136627317;
        private static long c02 = 56437149207651573;
        private static uint c03 = 0b01010000U;


        public static string A(string a)
        {
            if (a.Length == 13 && a.Replace("0", "").Replace("1", "").Length == 0 && (M(b00, b01) == Convert.ToUInt32(a, 2)))
            {
                return II(b00) + II(b01) + II(b02) + II(b03) + II(b04) + (c01+c02).ToString() + II(c03);
            }
            return a;
        }

        private static string II(uint ii)
        {
            ASCIIEncoding a = new ASCIIEncoding();
            byte[] b = { (byte)ii };
            return a.GetString(b);
        }

        private static uint M(uint a, uint b)
        {
            uint c;
            c = 0;
            while (a != 0)
            {
                if ((a & 1) == 1)
                    c ^= b;
                b <<= 1;
                a >>= 1;
            }
            return c;
        }
    }
}
