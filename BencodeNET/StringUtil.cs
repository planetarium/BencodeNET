using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BencodeNET
{
    internal class StringUtil
    {
        public static bool IsNullOrWhiteSpace(String s)
        {
            return s == null || s.Trim() == "";
        }
    }
}
