using System;
using System.Web.Http;

namespace CmdWebApp.Controllers
{
    public class HealthController : ApiController
    {
        // GET: api/Health
        public string Get()
        {
            return $"Pong @ {DateTime.Now}";
        }

        // GET: api/Health/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Health
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Health/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Health/5
        public void Delete(int id)
        {
        }
    }
}
