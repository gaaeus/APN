﻿using System.Collections.Generic;
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
        public async Task<IEnumerable<Image>> Get()
        {
            var imageDBcontext = HttpContext.RequestServices.GetService(typeof(ImageDBContext)) as ImageDBContext;

            return await imageDBcontext.GetImages();
        }

        // GET: api/Image/5
        [HttpGet("{id}", Name = "GetImage")]
        public async Task<Image> Get(int id)
        {
            var imageDBcontext = HttpContext.RequestServices.GetService(typeof(ImageDBContext)) as ImageDBContext;

            return await imageDBcontext.GetImage(id);
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
