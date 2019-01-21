using System.Collections.Generic;
using System.Threading.Tasks;
using APN.DBContexts;
using APN.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        // GET: api/Photo
        [HttpGet]
        public async Task<IEnumerable<Photo>> Get()
        {
            var PhotoDBcontext = HttpContext.RequestServices.GetService(typeof(PhotoDBContext)) as PhotoDBContext;

            return await PhotoDBcontext.GetPhotos();
        }

        // GET: api/Photo/5
        [HttpGet("{id}", Name = "GetPhoto")]
        public async Task<Photo> Get(int id)
        {
            var PhotoDBcontext = HttpContext.RequestServices.GetService(typeof(PhotoDBContext)) as PhotoDBContext;

            return await PhotoDBcontext.GetPhoto(id);
        }

        // POST: api/Photo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Photo/5
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
