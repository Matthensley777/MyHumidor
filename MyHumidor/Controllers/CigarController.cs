using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyHumidor.Models;
using MyHumidor.Services;

namespace MyHumidor.Controllers
{
    [RoutePrefix("api/cigars")]
    public class CigarController
    {
            [Route, HttpGet]
            public HttpResponseMessage GetList()
            {
                var repository = new CigarRepository();
                var result = repository.ListAllCigars();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }

            [Route, HttpPost]
            public HttpResponseMessage AddCigars(CigarDTO cigar)
            {
                var repository = new CigarRepository();
                var result = repository.Create(cigar);

                if (result)
                    return Request.CreateResponse(HttpStatusCode.Created);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "no!");
            }         

    }
}