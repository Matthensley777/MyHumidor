using Dapper;
using MyHumidor.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace MyHumidor.Services
{
    public class CigarWhiskeyRepository
    {
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MyHumidor"].ConnectionString);
        }

        public WhiskeyCigarDTO GetByCigarId(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<WhiskeyCigarDTO>(@"select * from Cigar where CigarID = @id", new { id });

                return result;
            }
        }
        public WhiskeyCigarDTO GetByWhiskeyId(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<WhiskeyCigarDTO>(@"select * from Whiskey where WhiskeyID = @id", new { id });

                return result;
            }
        }
    }
}