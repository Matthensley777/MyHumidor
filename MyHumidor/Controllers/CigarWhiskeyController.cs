using MyHumidor.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyHumidor.Controllers
{
    [RoutePrefix("api/whiskeycigars")]
    public class CigarwhiskeyController : ApiController
    {
        [Route("{id}/cigar"), HttpGet]
        public HttpResponseMessage GetByCigarId(int id)
        {
            var repo = new CigarWhiskeyRepository();
            var result = repo.GetByCigarId(id);


            return (result != null)
                ? Request.CreateResponse(HttpStatusCode.OK, result)
                : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No Cigar for you!");
        }

        [Route("{id}/whiskey"), HttpGet]
        public HttpResponseMessage GetByWhiskeyId(int id)
        {
            var repo = new CigarWhiskeyRepository();
            var result = repo.GetByWhiskeyId(id);

            return (result != null)
                ? Request.CreateResponse(HttpStatusCode.OK, result)
                : Request.CreateResponse(HttpStatusCode.InternalServerError, "no Whiskey for you!");
        }
    }
}