using exam_back.DTOs;
using exam_back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exam_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAllPatients()
        {
            var patients = _service.GetAllPatients();
            return Ok(patients);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var patient =await _service.GetPatientById(id);
            return Ok(patient);
        }

        [HttpPost]
        public IActionResult AddPatient([FromBody] PatientDto patient)
        {
            try
            {
                _service.AddPatient(patient);
                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public IActionResult UpdatePatient([FromBody] PatientDto patient)
        {
            try
            {
                _service.AddPatient(patient);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            bool result = await _service.DeletePatient(id);
            return result ? Ok() : NotFound($"Patient with Id {id} does not exist.");
        }

    }
}
