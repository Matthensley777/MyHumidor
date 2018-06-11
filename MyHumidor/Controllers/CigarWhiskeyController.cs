using MyHumidor.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyHumidor.Controllers
{
    [RoutePrefix("api/cigars")]
    public class EmployeeComputerController : ApiController
    {
        [Route("{id}"), HttpGet]
        public HttpResponseMessage GetByCigarId(int id)
        {
            var repo = new CigarWhiskeyRepository();
            var result = repo.GetByCigarId(id);


            return (result != null)
                ? Request.CreateResponse(HttpStatusCode.OK, result)
                : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not get Cigar by ID");
        }

        [Route("{id}/cigar"), HttpGet]
        public HttpResponseMessage GetByWhiskeyId(int id)
        {
            var repo = new CigarWhiskeyRepository();
            var result = repo.GetByWhiskeyId(id);

            return (result != null)
                ? Request.CreateResponse(HttpStatusCode.OK, result)
                : Request.CreateResponse(HttpStatusCode.NoContent, result = null);
        }
    }
}