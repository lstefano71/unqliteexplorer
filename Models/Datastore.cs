using System;
using System.Collections.Generic;
using System.Data.Unqlite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnQLiteExplorer.Models
{
    public class Datastore
    {
        public Datastore()
            : this(String.Empty, String.Empty)
        {
            this.FullName = String.Empty;
        }

        public Datastore(String name, String location)
        {
            this.Name = name;
            this.Location = location;
            MakeFullName(name, location);
            this.Status = DatastoreStatus.Disconnected;
            this.FavoriteNumber = Constants.InvalidInt32;
        }

        public Datastore(String fullName)
        {
            this.FullName = fullName;
            String name, location;
            this.ExtractFileNameAndLocation(out name, out location);
            this.Name = name;
            this.Location = location;
            this.Status = DatastoreStatus.Disconnected;
            this.FavoriteNumber = Constants.InvalidInt32;
        }

        public void Open()
        {
            this.Db = UnqliteDB.Create();
            this.Db.Open(this.FullName, System.Data.Unqlite.UnqliteOpenMode.CREATE);
            this.Status = DatastoreStatus.Connected;
        }

        public List<UnqQLiteKeyValue> GetAllKVEntries()
        {
            List<UnqQLiteKeyValue> results = new List<UnqQLiteKeyValue>();
            using (var cursor = this.Db.CreateKeyValueCursor())
            {
                //cursor.Seek("Folder-NetworkDevices");
                while (cursor.Read())
                {
                    String key = cursor.GetKey();
                    String value = cursor.GetValue();
                    results.Add(new UnqQLiteKeyValue(key, value));
                    cursor.Next();
                }
            }

            return results;
        }

        public Boolean Save(UnqQLiteKeyValue kv)
        {
            if (kv != null)
            {
                return this.Db.SaveKeyValue(kv.Key, kv.Value);
            }

            return false;
        }

        public Boolean Append(UnqQLiteKeyValue kv)
        {
            Boolean result = false;
            if (kv != null)
            {
                result = this.Db.AppendKeyValue(kv.Key, kv.Value);
            }

            return result;
        }

        public Boolean Delete(UnqQLiteKeyValue kv)
        {
            Boolean result = false;
            if (kv != null)
            {
                result = this.Db.DeleteKeyValue(kv.Key);
            }

            return result;
        }

        public void Close()
        {
            if (this.Db != null)
            {
                this.Db.Close();
                this.Status = DatastoreStatus.Disconnected;
            }
        }

        public UnqliteDB Db { get; set; }

        private void ExtractFileNameAndLocation(out String name,
            out String location)
        {
            name = String.Empty;
            location = String.Empty;
            if (!String.IsNullOrEmpty(this.FullName))
            {
                FileInfo fi = new FileInfo(this.FullName);
                name = fi.Name;
                location = fi.Directory.Name;
            }
        }

        private static String MakeFullName(String location, String name)
        {
            if (!String.IsNullOrEmpty(location) &&
                !String.IsNullOrEmpty(name))
            {
                if (!location.EndsWith("\\"))
                    location += "\\";
                return String.Format("{0}{1}", location, name);
            }
            else 
            {
                return String.Empty;
            }
        }

        public String Name { get; set; }
        public String Location { get; set; }
        public String FullName { get; set; }
        public DatastoreStatus Status { get; set; }
        public Int32 FavoriteNumber { get; set; }
    }
}
