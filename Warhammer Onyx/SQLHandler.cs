using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Warhammer_Onyx
{
    public class SQLHandler
    {

        public SQLHandler(string username, string password)
        {
            try
            {
                SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
                stringBuilder.DataSource = "disruptionsql.database.windows.net";
                stringBuilder.UserID = username;
                stringBuilder.Password = password;
                stringBuilder.InitialCatalog = "wfrp";

                using (SqlConnection wfrpConnection = new SqlConnection(stringBuilder.ConnectionString))
                {
                    wfrpConnection.Open();
                    Console.WriteLine("Connection Opened!");
                    wfrpConnection.Close();
                }

            }catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
