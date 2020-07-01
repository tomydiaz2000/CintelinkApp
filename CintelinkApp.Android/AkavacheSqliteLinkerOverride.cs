using Akavache.Sqlite3;
using System;

namespace CintelinkApp.Droid
{
    class AkavacheSqliteLinkerOverride
    {
        [Preserve]
        public static class LinkerPreserve
        {
            static LinkerPreserve()
            {
                throw new Exception(typeof(SQLitePersistentBlobCache).FullName);
            }
        }


        public class PreserveAttribute : Attribute
        {
        }
    }
}