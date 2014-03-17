using System;
using System.Collections.Generic;
using System.Data.Unqlite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnQLiteExplorer.Models;

namespace UnQLiteExplorer
{
    internal static class SystemService
    {
        public static void StoreFavoriteDatastore(Datastore ds)
        {
            if (ds != null)
            {
                UnqliteDB db = UnqliteDB.Create();
                db.Open(SystemDbFullName, UnqliteOpenMode.CREATE);

                String key = String.Empty;
                Int32 count = db.GetKeyValue(SystemKeys.FavoriteCount).ToInt32();
                for (Int32 i = 0; i < count; i++)
                {
                    key = GetFavoriteFullNameKey(i);
                    String value = db.GetKeyValue(key);
                    if (value.InvariantCultureIgnoreCaseEquals(ds.FullName))
                    {
                        return;
                    }
                }

                key = GetFavoriteFullNameKey(count);
                db.SaveKeyValue(key, ds.FullName);
                ds.FavoriteNumber = count;

                count++;
                db.SaveKeyValue(SystemKeys.FavoriteCount, count.ToString());

                db.Close();
            }
        }

        public static void RemoveFavoriteDataStore(Datastore ds)
        {
            if (ds == null)
            {
                return;
            }

            Int32 fn = ds.FavoriteNumber;
            if (fn == Constants.InvalidInt32)
            {
                return;
            }

            UnqliteDB db = UnqliteDB.Create();
            db.Open(SystemDbFullName, UnqliteOpenMode.CREATE);

            String key = GetFavoriteFullNameKey(fn);
            db.DeleteKeyValue(key);

            Int32 count = db.GetKeyValue(SystemKeys.FavoriteCount).ToInt32();
            count--;
            db.SaveKeyValue(SystemKeys.FavoriteCount, count.ToString());

            db.Close();
        }

        public static void ClearFavoriteDataStore()
        {
            UnqliteDB db = UnqliteDB.Create();
            db.Open(SystemDbFullName, UnqliteOpenMode.CREATE);

            Int32 count = db.GetKeyValue(SystemKeys.FavoriteCount).ToInt32();
            for (int i = 0; i < count; i++)
            {
                String key = GetFavoriteFullNameKey(i);
                db.DeleteKeyValue(key);
            }
            
            db.SaveKeyValue(SystemKeys.FavoriteCount, "0");
            db.Close();
        }

        public static List<Datastore> GetAllFavoriteDatastores()
        {
            UnqliteDB db = UnqliteDB.Create();
            db.Open(SystemDbFullName, UnqliteOpenMode.CREATE);

            Int32 count = db.GetKeyValue(SystemKeys.FavoriteCount).ToInt32();
            List<Datastore> results = new List<Datastore>((int)count); 
            for (Int32 i = 0; i < count; i++)
            {
                String key = GetFavoriteFullNameKey(i);
                String fullName = db.GetKeyValue(key);

                Datastore ds = new Datastore(fullName);
                ds.FavoriteNumber = i;
                results.Add(ds);
            }

            db.Close();
            return results;
        }

        private static String GetFavoriteFullNameKey(Int32 count)
        {
            String key = String.Format("{0}-{1}", SystemKeys.FavoriteFullName, count);
            return key;
        }

        static SystemService()
        {
            String baseDir = AppDomain.CurrentDomain.BaseDirectory;
            if (!baseDir.EndsWith("\\"))
                baseDir += "\\";
            SystemDbFullName = String.Format("{0}{1}",
                baseDir, SystemDbName);

            UnqliteDB db = UnqliteDB.Create();
            db.Open(SystemDbFullName, UnqliteOpenMode.CREATE);
            String count = db.GetKeyValue(SystemKeys.FavoriteCount);
            if (String.IsNullOrEmpty(count))
            {
                db.SaveKeyValue(SystemKeys.FavoriteCount, "0");
            }
            
            db.Close();
        }

        private const String SystemDbName = "system.unqlite";
        private static String SystemDbFullName { get; set; }

        private static class SystemKeys 
        {
            public const String FavoriteCount = "Favorite-Count";
            public const String FavoriteFullName = "Favorite-FullName";
        }
    }
}
