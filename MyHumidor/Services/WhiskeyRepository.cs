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
                                                       ([WhiskeyID]
                                                       ,[Brand]
                                                       ,[Type])
                                                    VALUES
                                                        (@WhiskeyID,
                                                         @Brand,
                                                         @Type)", whiskey);

                return addWhiskey == 1;
            }
        }

        public IEnumerable<WhiskeyDTO> ListAllWhiskeys()
        {
            using (var db = GetConnection())
            {
                db.Open();
                var getWhiskeyList = db.Query<WhiskeyDTO>(@"SELECT Whiskey.WhiskeyID
                                                                    , Whiskey.Brand
                                                                    , Whiskey.Type
                                                                    
                                                            FROM Whiskey");

                return getWhiskeyList;
            }
        }


    }
}