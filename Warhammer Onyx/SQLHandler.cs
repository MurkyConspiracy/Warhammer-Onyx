using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Warhammer_Onyx
{
    public class SQLHandler
    {
        private SqlConnectionStringBuilder sqlConnectionBuilder;
        private Boolean connectionTested = false;
        public SQLHandler(string username, string password)
        {

            sqlConnectionBuilder = new SqlConnectionStringBuilder();
            sqlConnectionBuilder.DataSource = "disruptionsql.database.windows.net";
            sqlConnectionBuilder.UserID = username;
            sqlConnectionBuilder.Password = password;
            sqlConnectionBuilder.InitialCatalog = "wfrp";

        }

        public Boolean TestConnection()
        {
            try
            {
                using (SqlConnection wfrpConnection = new SqlConnection(this.sqlConnectionBuilder.ConnectionString))
                {
                    wfrpConnection.Open();
                    Console.WriteLine("Connection Opened!");
                    wfrpConnection.Close();
                    return (connectionTested = true);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public DataTable getTable(string tableName)
        {
            if (!connectionTested)
                throw new Exception("SQL Connection not tested");

            using (SqlConnection wfrpConnection = new SqlConnection(this.sqlConnectionBuilder.ConnectionString))
            {
                string tableQuery = "SELECT * FROM " + tableName;
                using (SqlCommand tableCommand = new SqlCommand(tableQuery,wfrpConnection))
                {
                    DataTable queriedTable = new DataTable(tableName);
                    SqlDataAdapter queryDataAdapter = new SqlDataAdapter(tableCommand);

                    wfrpConnection.Open();
                    queryDataAdapter.Fill(queriedTable);
                    wfrpConnection.Close();

                    return queriedTable;

                }
            }
        }

    }
}
