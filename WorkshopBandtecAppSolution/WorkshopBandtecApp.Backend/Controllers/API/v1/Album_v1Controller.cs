using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WorkshopBandtecApp.Backend.Controllers.API.v1
{
    [Authorize]
    [RoutePrefix("api/v1/album")]
    public class Album_v1Controller : ApiController
    {
        // GET: api/Album_v1
        [Route()]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Album_v1/5
        [Route("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Album_v1
        [Route()]
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Album_v1/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/Album_v1/5
        //public void Delete(int id)
        //{
        //}
    }
}
