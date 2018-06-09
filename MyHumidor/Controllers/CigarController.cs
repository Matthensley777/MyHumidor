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
    public class CigarController : ApiController
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

        [Route("{Id}"), HttpPut]
        public HttpResponseMessage Edit(CigarDTO cigar, int id)
        {
            var repository = new CigarRepository();
            var result = repository.Edit(cigar, id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("{Id}"), HttpGet]
        public HttpResponseMessage GetCigar(int id)
        {
            var repository = new CigarRepository();
            var result = repository.GetCigarById(id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("{id}/delete"), HttpDelete]
        public HttpResponseMessage DeleteCigar(int id)
        {
            var repo = new CigarRepository();
            var result = repo.Delete(id);

            return result
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cigar can't be deleted");
        }

    }
}