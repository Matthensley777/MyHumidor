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
    [RoutePrefix("api/whiskeys")]
    public class WhiskeyController : ApiController
    {
       // [Route, HttpGet]
       // public HttpResponseMessage GetList()
       // {
       //     var repository = new WhiskeyRepository();
       //     var result = repository.ListAllWhiskeys();

       //     return Request.CreateResponse(HttpStatusCode.OK, result);
      //  }

        [Route, HttpPost]
        public HttpResponseMessage AddWhiskeys(WhiskeyDTO Whiskey)
        {
            var repository = new WhiskeyRepository();
            var result = repository.Create(Whiskey);

            if (result)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "no!");
        }

        [Route("{id}/delete"), HttpDelete]
        public HttpResponseMessage DeleteWhiskey(int id)
        {
            var repo = new WhiskeyRepository();
            var result = repo.Delete(id);

            return result
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Whiskey can't be deleted");
        }

        [Route("user/{userId}"), HttpGet]
        public HttpResponseMessage GetWhiskeyListByUser(int userId)
        {
            var repository = new WhiskeyRepository();
            var result = repository.ListAllWhiskeysByUser(userId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }
}