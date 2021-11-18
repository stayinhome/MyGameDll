using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseHelper
{
    public class DataBaseHelper
    {
        private string _ConnectionString = "";
        private SqlConnection _sqlConnection = new SqlConnection();

        private void OpenDatabase()
        {
            try
            {

                if(_sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    _sqlConnection.ConnectionString = _ConnectionString;
                    _sqlConnection.Open();
                }

            }
            catch (Exception e)
            {
                
            }

        }

        private void CloseDatabase()
        {
            try
            {
                if(_sqlConnection.State != System.Data.ConnectionState.Closed)
                {
                    this._sqlConnection.Close();
                }

            }
            catch (Exception e)
            {

            }
        }

        public DataTable GetDataTable(string sql)
        {
            DataTable dataTable = GetDataSet(sql).Tables[0];

            return dataTable;


        }

        public DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();

            try
            {
                OpenDatabase();
                SqlCommand cmd = new SqlCommand(sql, this._sqlConnection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

            }
            catch (Exception e)
            {

            }
            finally
            {
                CloseDatabase();

            }

            return ds;
        }


    }
}
