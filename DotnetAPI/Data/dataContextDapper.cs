using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DotnetAPI.models{
    public class dataContextDapper{
         private IConfiguration _config;
        public dataContextDapper(IConfiguration config)
        {
            _config=config;
        }
        //database connection 
     //string _connectionstring = @"server=localhost\sqlexpress;database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true";
        //inserting the data in the database
        public IEnumerable<S> Loadingdata<S>(String sql)
        {
           IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("Defaultconnection"));
           return dbConnection.Query<S>(sql);
        } 
        public User Loadingdatasingle(string sql)
{
    using (IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("Defaultconnection")))
    {
        return dbConnection.QuerySingle<User>(sql);
    }
}

        public int Executesql(String sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("Defaultconnection"));
           return dbConnection.Execute(sql);
        } 
    }
}