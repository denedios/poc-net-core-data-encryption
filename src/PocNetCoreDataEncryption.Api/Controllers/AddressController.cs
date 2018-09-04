using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PocNetCoreDataEncryption.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        // GET: api/Address
        [HttpGet]
        public IEnumerable<string> GetAddresses()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Address/5
        [HttpGet("{id}", Name = "GetAddress")]
        public string GetAddress(int id)
        {
            return "value";
        }

        // POST: api/Address
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Address/5
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
