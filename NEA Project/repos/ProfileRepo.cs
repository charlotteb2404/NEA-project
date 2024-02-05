using Microsoft.Data.SqlClient;
using NEA_Project.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;


namespace NEA_Project.repos
{
    public class ProfileRepo
    {
        private string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=game.db;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public ProfileRepo()
        {

        }
        private IDbConnection db { get { return new SqlConnection(ConnectionString); } }
        public List<DatabaseProfile> getall()
        {
            var sql = "select * from dbo.Profiles orderby BestScore desc";
            return db.Query<DatabaseProfile>(sql, null, commandType: CommandType.Text).ToList();
        }
        public void Create(string ProfileName) 
        {
            var sql = $"insert dbo.Profiles (ProfileName, BestScore) values('{ProfileName}', 0)";
            db.Execute(sql); 
        }
    }
}
