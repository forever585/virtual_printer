using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Printer
{
    public enum DbType
    {
        MSACCESS,
        SQLITE3,
    }

    interface IDbProvider
    {
        void openDb();

        void closeDb();

        void executeNonQuery(string qry);

        DataTable executeQuery(string qry);
    }

    class DbProviderManager
    {
        private DbType mDbType = DbType.SQLITE3;

        private static DbProviderManager mInstance;

        public static DbProviderManager Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new DbProviderManager();
                }
                return mInstance;
            }
        }

        public IDbProvider DbProvider
        {
            get;
            set;
        }

        public void createDbProvider()
        {
            switch (mDbType)
            {
                case DbType.MSACCESS:
                    DbProvider = new AccessProvider(); 
                    break;
                case DbType.SQLITE3:
                    DbProvider = new SqliteProvider();
                    break;
                default:
                    DbProvider = new SqliteProvider();
                    break;
            }
        }
    }
}
