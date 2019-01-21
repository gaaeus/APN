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
    public class ImageController : ControllerBase
    {
        // GET: api/Image
        [HttpGet]
        public async Task<IEnumerable<Audio>> Get()
        {
            AudioDBContext audioDBcontext = HttpContext.RequestServices.GetService(typeof(AudioDBContext)) as AudioDBContext;

            return await audioDBcontext.GetAudios();
        }

        // GET: api/Image/5
        [HttpGet("{id}", Name = "GetImage")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Image
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Image/5
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
