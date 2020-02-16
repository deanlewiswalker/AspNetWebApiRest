using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AspNetWebApiRest.Models;

namespace AspNetWebApiRest.Controllers
{
    public class EntrantController : ApiController
    {
        private static List<Entrant> _entrants { get; set; } = new List<Entrant>();

        // GET api/<controller>
        public IEnumerable<Entrant> Get()
        {
            return _entrants;
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var entrant = _entrants.FirstOrDefault(t => t.id == id);

            if (entrant == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);                
            }

            return Request.CreateResponse(HttpStatusCode.OK, entrant);
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]Entrant model)
        {
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var entId = 0;
            if (_entrants.Count > 0)
            {
                entId = _entrants.Max(i => i.id);
            }
            model.id = entId + 1;

            _entrants.Add(model);
            return Request.CreateResponse(HttpStatusCode.Created, model);            
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            var entrant = _entrants.FirstOrDefault(t => t.id == id);

            if (entrant == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _entrants.Remove(entrant);
            return Request.CreateResponse(HttpStatusCode.OK);            
        }
    }
}