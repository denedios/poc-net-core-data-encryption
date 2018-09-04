using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocNetCoreDataEncryption.DAL;
using PocNetCoreDataEncryption.Domain;
using PocNetCoreDataEncryption.Domain.DTOs;
using PocNetCoreDataEncryption.Domain.Entities;

namespace PocNetCoreDataEncryption.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }


        // GET: api/Patient
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var entities = (await _patientRepository.GetAsync(take: 10)).ToList();
                var patients = _mapper.Map<IEnumerable<PatientDto>>(entities);
                return Ok(patients);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        // GET: api/Patient/5
        [HttpGet("{id}", Name = "GetPatient")]
        public async Task<IActionResult> GetPatient(int id)
        {
            try
            {
                var entity = await _patientRepository.GetByIdAsync(id);
                var patient = _mapper.Map<PatientDto>(entity);
                return Ok(patient);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST: api/Patient
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient patient)
        {
            try
            {
                _patientRepository.AddOrUpdate(patient);
                await _patientRepository.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
