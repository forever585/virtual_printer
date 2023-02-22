using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;

namespace Printer
{
    class AccessProvider : IDbProvider
    {
        private OleDbConnection mOleDbConnection = null;

        void IDbProvider.openDb()
        {
            try
            {
                mOleDbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath.MDBFile);
                mOleDbConnection.Open();
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        void IDbProvider.closeDb()
        {
            try
            {
                mOleDbConnection.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        DataTable dataTable(string qry)
        {
            return null;
        }

        public void executeNonQuery(string qry)
        {
        }

        public DataTable executeQuery(string qry)
        {
            return null;
        }
    }
}
