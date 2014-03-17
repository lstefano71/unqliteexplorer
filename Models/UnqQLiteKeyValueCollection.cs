using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnQLiteExplorer.Models
{
    public class UnqQLiteKeyValueCollection : ObservableCollection<UnqQLiteKeyValue>
    {
        public UnqQLiteKeyValueCollection()
            : base()
        { 
        }

        public UnqQLiteKeyValueCollection(IEnumerable<UnqQLiteKeyValue> collection)
            : base(collection)
        { 
        }

        public UnqQLiteKeyValueCollection(List<UnqQLiteKeyValue> list)
            : base(list)
        {
        }

        //public void AddKeyValue(UnqQLiteKeyValue kv)
        //{
        //    if (!this.Contains(kv, new UnqQLiteKeyValueComparer()))
        //    {
        //        this.Add(kv);
        //    }
        //}
    }
}
