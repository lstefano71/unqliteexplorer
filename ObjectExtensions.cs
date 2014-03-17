using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnQLiteExplorer
{
    public static class ObjectExtensions
    {
        public static Boolean InvariantCultureIgnoreCaseEquals(this String src, String dest)
        {
            return src.Equals(dest, StringComparison.InvariantCultureIgnoreCase);
        }

        public static Int32 ToInt32(this String value)
        {
            Int32 result;
            if (Int32.TryParse(value, out result))
            {
                return result;
            }

            return Constants.InvalidInt32;
        }
    }
}
