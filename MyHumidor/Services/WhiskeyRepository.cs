using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MyHumidor.Models;

namespace MyHumidor.Services
{
    public class WhiskeyRepository
    {
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MyHumidor"].ConnectionString);
        }

        public bool Create(WhiskeyDTO whiskey)
        {
            using (var db = GetConnection())
            {


                db.Open();
                var addWhiskey = db.Execute(@"INSERT INTO [dbo].[Whiskey]
                                                       (
                                                       [Brand]
                                                       ,[Type]
                                                       ,[UserID])
                                                    VALUES
                                                        (
                                                         @Brand,
                                                         @Type,
                                                         @UserID)", whiskey);

                return addWhiskey == 1;
            }
        }


        public IEnumerable<WhiskeyDTO> ListAllWhiskeysByUser(int userId)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var GetWhiskeyListByUser = db.Query<WhiskeyDTO>(@"SELECT Whiskey.WhiskeyID
                                                                    , Whiskey.Brand
                                                                    , Whiskey.Type
                                                                    , Whiskey.UserID
                                                            FROM Whiskey WHERE UserID = @userId", new { userId });

                return GetWhiskeyListByUser;
            }
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.Execute(@"DELETE FROM Whiskey WHERE WhiskeyID = @id", new { id });

                return result >= 1;
            }
        }

    }
}