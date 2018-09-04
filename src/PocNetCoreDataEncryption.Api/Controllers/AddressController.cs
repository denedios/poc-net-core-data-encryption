using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PocNetCoreDataEncryption.DAL;
using PocNetCoreDataEncryption.Domain;

namespace PocNetCoreDataEncryption.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        // GET: api/Address
        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            try
            {
                var addresses = await _addressRepository.GetAsync(take: 10);
                return Ok(addresses.ToArray());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET: api/Address/5
        [HttpGet("{id}", Name = "GetAddress")]
        public async Task<IActionResult> GetAddress(int id)
        {
            try
            {
                var address = await _addressRepository.GetByIdAsync(id);
                return Ok(address);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST: api/Address
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Address address)
        {
            try
            {
                _addressRepository.AddOrUpdate(address);
                await _addressRepository.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        
    }
}
