using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnQLiteExplorer.Models
{
    public class UnqQLiteKeyValueComparer : IEqualityComparer<UnqQLiteKeyValue>
    {
        public bool Equals(UnqQLiteKeyValue x, UnqQLiteKeyValue y)
        {
            return x.Key.InvariantCultureIgnoreCaseEquals(y.Key);
        }

        public int GetHashCode(UnqQLiteKeyValue obj)
        {
            return obj.GetHashCode();
        }
    }
}
