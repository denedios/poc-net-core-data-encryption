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
    public class PatientController : ControllerBase
    {

        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }


        // GET: api/Patient
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var patients = await _patientRepository.GetAsync(take: 10);
                return Ok(patients.ToArray());
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
                var patient = await _patientRepository.GetByIdAsync(id);
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
