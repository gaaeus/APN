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
    public class VideoController : ControllerBase
    {
        // GET: api/Video
        [HttpGet]
        public async Task<IEnumerable<Video>> Get()
        {
            var VideoDBcontext = HttpContext.RequestServices.GetService(typeof(VideoDBContext)) as VideoDBContext;

            return await VideoDBcontext.GetVideos();
        }

        // GET: api/Video/5
        [HttpGet("{id}", Name = "GetVideo")]
        public async Task<Video> Get(int id)
        {
            var VideoDBcontext = HttpContext.RequestServices.GetService(typeof(VideoDBContext)) as VideoDBContext;

            return await VideoDBcontext.GetVideo(id);
        }

        // POST: api/Video
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Video/5
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
