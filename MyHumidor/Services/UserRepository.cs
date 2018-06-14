using Dapper;
using MyHumidor.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace MyHumidor.Services
{
    public class UserRepository
    {
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MyHumidor"].ConnectionString);
        }

        public UserDTO GetUserByCigarId(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<UserDTO>(@"select * from User where UserID = @id", new { id });

                return result;
            }
        }
        public CigarDTO GetByCigarId(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<CigarDTO>(@"select * from Cigar where CigarID = @id", new { id });

                return result;
            }
        }
    }
}