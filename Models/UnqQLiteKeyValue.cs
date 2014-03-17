using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnQLiteExplorer.Models
{
    public sealed class UnqQLiteKeyValue : IEditableObject
    {
        public UnqQLiteKeyValue(String key, String value)
        {
            this.Key = key;
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is UnqQLiteKeyValue)
            {
                UnqQLiteKeyValue kv = obj as UnqQLiteKeyValue;
                return (kv.Key.InvariantCultureIgnoreCaseEquals(this.Key));
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }

        public String Key { get; set; }
        public String Value { get; set; }

        private String OriginalKey { get; set; }
        private String OriginalValue { get; set; }

        public void BeginEdit()
        {
            // keep the original value.
            this.OriginalKey = this.Key;
            this.OriginalValue = this.Value;
        }

        public void CancelEdit()
        {
            this.Key = this.OriginalKey;
            this.Value = this.OriginalValue;
        }

        public void EndEdit()
        {
            
        }
    }
}
