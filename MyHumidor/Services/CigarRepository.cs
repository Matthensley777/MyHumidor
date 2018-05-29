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
                                                       ([CigarID]
                                                       ,[Brand]
                                                       ,[Series]
                                                       ,[Description]
                                                       ,[Photo]
                                                       ,[DatePurchased]
                                                    VALUES
                                                        (@CigarID,
                                                         @Brand,
                                                         @Series,
                                                         @Description,
                                                         @Photo,
                                                         @DatePurchased)", cigar);

                return addCigar == 1;
            }
        }



    }
}