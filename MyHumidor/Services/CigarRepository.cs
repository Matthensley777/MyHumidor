using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MyHumidor.Models;

namespace MyHumidor.Services
{
    public class CigarRepository
    {
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MyHumidor"].ConnectionString);
        }

        public bool Create(CigarDTO cigar)
        {
            using (var db = GetConnection())
            {


                db.Open();
                var addCigar = db.Execute(@"INSERT INTO [dbo].[Cigar]
                                                       ([Brand]
                                                       ,[Series]
                                                       ,[Description]
                                                       ,[Photo]
                                                       ,[WhiskeyID]
                                                       ,[UserID]
                                                       ,[DatePurchased])
                                                    VALUES
                                                        (@CigarBrand,
                                                         @Series,
                                                         @Description,
                                                         @Photo,
                                                         @WhiskeyID,
                                                         @UserID,
                                                         @DatePurchased)", cigar);

                return addCigar == 1;
            }
        }

        public IEnumerable<CigarDTO> ListAllCigarsByUser(int userId)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var getCigarList = db.Query<CigarDTO>(@"SELECT Cigar.CigarID
                                                                    , Cigar.Brand as CigarBrand
                                                                    , Cigar.Series
                                                                    , Cigar.Description
                                                                    , Cigar.Photo
                                                                    , Cigar.WhiskeyID
                                                                    , Cigar.UserID
                                                                    , Cigar.DatePurchased 
                                                                    , whiskey.Brand as WhiskeyBrand

                                                            FROM Cigar
                                                                    join whiskey on cigar.WhiskeyID = whiskey.WhiskeyID
                                                                    where UserID = @userid",new { userId });


                return getCigarList;
            }
            throw new NotImplementedException();
            
        }

        public IEnumerable<CigarDTO> ListAllCigars()
        {
            using (var db = GetConnection())
            {
                db.Open();
                var getCigarList = db.Query<CigarDTO>(@"SELECT Cigar.CigarID
                                                                    , Cigar.Brand as CigarBrand
                                                                    , Cigar.Series
                                                                    , Cigar.Description
                                                                    , Cigar.Photo
                                                                    , Cigar.WhiskeyID
                                                                    , Cigar.UserID
                                                                    , Cigar.DatePurchased 
                                                                    , whiskey.Brand as WhiskeyBrand

                                                            FROM Cigar
                                                                    join whiskey on cigar.WhiskeyID = whiskey.WhiskeyID");


                return getCigarList;
            }
        }

        public bool Edit(CigarDTO cigar, int id)
        {
            using (var db = GetConnection())
            {
                cigar.CigarID = id;
                db.Open();
                var result = db.Execute(@"UPDATE [dbo].[Cigar]
                                             SET [Brand] = @CigarBrand
                                                ,[Series] = @Series
                                                ,[Description] = @description
                                                ,[Photo] = @photo
                                                ,[WhiskeyID] = @WhiskeyID
                                          WHERE cigarID = @cigarID", cigar);

                return result == 1;
            }
        }

        public CigarDTO GetCigarById(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.QueryFirstOrDefault<CigarDTO>(@"SELECT [CigarID]
                                                                          ,C.Brand as [CigarBrand]
                                                                          ,[Series]
                                                                          ,[Description]
                                                                          ,[Photo]
                                                                          ,W.[WhiskeyID]
                                                                          ,W.Brand as WhiskeyBrand
                                                                      FROM [Cigar] as C
                                                                        join whiskey as W on C.WhiskeyID = W.WhiskeyID
                                                                      WHERE CigarID = @id", new { id });

                return result;
            }
        }

        public bool Delete(int id)
        {
            using (var db = GetConnection())
            {
                db.Open();
                var result = db.Execute(@"DELETE FROM Cigar WHERE CigarID = @id", new { id });

                return result >= 1;
            }
        }


    }
}