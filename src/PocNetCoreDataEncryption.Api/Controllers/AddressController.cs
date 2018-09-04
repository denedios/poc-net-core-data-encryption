using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocNetCoreDataEncryption.DAL;
using PocNetCoreDataEncryption.Domain.DTOs;
using PocNetCoreDataEncryption.Domain.Entities;

namespace PocNetCoreDataEncryption.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }


        // GET: api/Address
        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            try
            {
                var entities = await _addressRepository.GetAsync(take: 10);
                var addresses = _mapper.Map<IEnumerable<AddressDto>>(entities);
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
                var entity = await _addressRepository.GetByIdAsync(id);
                var address = _mapper.Map<AddressDto>(entity);
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
