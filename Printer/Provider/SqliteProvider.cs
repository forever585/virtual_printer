using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;

namespace Printer
{
    class SqliteProvider : IDbProvider
    {
        private SQLiteConnection mSQLiteConnection = null;

        public void openDb()
        {
            try
            {
                mSQLiteConnection = new SQLiteConnection("Data Source=" + FilePath.SqliteFile + ";Version=3;");
                mSQLiteConnection.Open();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        public void closeDb()
        {
            try
            {
                mSQLiteConnection.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        public void executeNonQuery(string qry)
        {
            SQLiteCommand sqliteCommand;
            sqliteCommand = mSQLiteConnection.CreateCommand();
            sqliteCommand.CommandText = qry;
            sqliteCommand.ExecuteNonQuery();
        }

        public DataTable executeQuery(string qry)
        {
            SQLiteDataReader sqliteReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = mSQLiteConnection.CreateCommand();
            sqliteCommand.CommandText = qry;
            sqliteReader = sqliteCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(sqliteReader);
                       
            return dataTable;
        }
    }
}
