using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APN.Models.Country;
using Microsoft.AspNetCore.Mvc;

namespace APN.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Country> Countries()
        {
        }
    }
}
