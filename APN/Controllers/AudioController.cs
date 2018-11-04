using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APN.DBContexts;
using APN.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        // GET: api/Audio
        [HttpGet]
        public IEnumerable<Audio> Get()
        {
            AudioDBContext audioDBcontext = HttpContext.RequestServices.GetService(typeof(AudioDBContext)) as AudioDBContext;

            return audioDBcontext.GetAudios();
        }

        // GET: api/Audio/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Audio
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Audio/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
