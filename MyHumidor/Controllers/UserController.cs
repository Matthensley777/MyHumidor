using MyHumidor.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyHumidor.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {

        [Route("{email}"), HttpGet]
        public HttpResponseMessage GetUserByEmail(string email)
        {
            var repo = new UserRepository();
            var result = repo.GetUserByEmail(email);

            return (result != null)
                ? Request.CreateResponse(HttpStatusCode.OK, result)
                : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "no!");
        }

        //[Route("{id}/Cigar"), HttpGet]
        //public HttpResponseMessage GetUserByCigarId(int id)
        //{
           // var repo = new CigarRepository();
            //var result = repo.GetByCigarId(id);

           // return (result != null)
               // ? Request.CreateResponse(HttpStatusCode.OK, result)
               // : Request.CreateResponse(HttpStatusCode.InternalServerError, "no Cigar for you!");
       // }
    }
}