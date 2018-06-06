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
                                                       ,[DatePurchased])
                                                    VALUES
                                                        (@Brand,
                                                         @Series,
                                                         @Description,
                                                         @Photo,
                                                         @DatePurchased)", cigar);

                return addCigar == 1;
            }
        }

        public IEnumerable<CigarDTO> ListAllCigars()
        {
            using (var db = GetConnection())
            {
                db.Open();
                var getCigarList = db.Query<CigarDTO>(@"SELECT Cigar.CigarID
                                                                    , Cigar.Brand
                                                                    , Cigar.Series
                                                                    , Cigar.Description
                                                                    , Cigar.Photo
                                                                    , Cigar.DatePurchased 
                                                            FROM Cigar");

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
                                             SET [Brand] = @brand
                                                ,[Series] = @Series
                                                ,[Description] = @description
                                                ,[Photo] = @photo
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
                                                                          ,[Brand]
                                                                          ,[Series]
                                                                          ,[Description]
                                                                          ,[Photo]
                                                                      FROM [dbo].[Cigar]
                                                                      WHERE CigarID = @id", new { id });

                return result;
            }
        }

        

    }
}