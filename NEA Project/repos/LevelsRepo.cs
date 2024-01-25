using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using NEA_Project.models;

namespace NEA_Project.repos
{
    public class LevelsRepo
    {
        private string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=game.db;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public LevelsRepo()
        {
            
        }
        private IDbConnection db { get { return new SqlConnection(ConnectionString); }}
        public List<DatabaseLevel> getall() 
        {
            var sql = "select * from dbo.Levels";
            return db.Query<DatabaseLevel>(sql, null, commandType: CommandType.Text).ToList();
        }
    }
}
