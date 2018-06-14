using MyHumidor.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyHumidor.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [Route("{id}/UserID"), HttpGet]
        public HttpResponseMessage GetUserById(int id)
        {
            var repo = new UserRepository();
            var result = repo.GetUserById(id);


            return (result != null)
                ? Request.CreateResponse(HttpStatusCode.OK, result)
                : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not a User");
        }

        [Route("{id}/Cigar"), HttpGet]
        public HttpResponseMessage GetUserByCigarId(int id)
        {
            var repo = new CigarRepository();
            var result = repo.GetUserByCigarId(id);

            return (result != null)
                ? Request.CreateResponse(HttpStatusCode.OK, result)
                : Request.CreateResponse(HttpStatusCode.InternalServerError, "no Cigar for you!");
        }
    }
}