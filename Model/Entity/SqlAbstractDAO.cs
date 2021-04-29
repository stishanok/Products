using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Model.Interface;

namespace Model.Entity
{
    public class SqlAbstractDAO : IAbstractDAO
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        
        public IDbConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("##### Connection open successfully");
            return connection;
        }

        public void ReleaseConnection(IDbConnection connection)
        {
            connection.Close();
            Console.WriteLine("##### Connection close successfully\n");
        }
    }
}