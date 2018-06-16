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

       

        //method that takes in a string email and returns a UserDTO
        public UserDTO GetUserByEmail(string email)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<UserDTO>(@"SELECT [UserID] 
                                                                          ,[FirstName]
                                                                          ,[LastName]
                                                                          ,[Email]
                                                                      FROM [User] as U
                                                                      WHERE Email = @email", new { email });

                return result;
            }
            //query by email,return result
        }

        //public CigarDTO GetByCigarId(int id)
        //{
            //using (var db = GetConnection())
            //{
                //db.Open();
                //var result = db.QueryFirstOrDefault<CigarDTO>(@"select * from Cigar where CigarID = @id", new { id });

                //return result;
            //}
        //}
    }
}