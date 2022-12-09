using exam_back.DTOs;
using exam_back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exam_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoriesController : ControllerBase
    {
        private readonly IMedicalHistoryService _service;

        public MedicalHistoriesController(IMedicalHistoryService service)
        {
            _service = service;
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAllHistories()
        {
            var histories = _service.GetAllHistories();
            return Ok(histories);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetHistoryById(Guid id)
        {
            var history = await _service.GetHistoryById(id);

            if (history is null)
            {
                return NotFound($"History with Id {id} does not exist.");
            }

            return Ok(history);
        }

        [Route("patient/{patientId}")]
        [HttpGet]
        public IActionResult GetPatientHistories(Guid patientId)
        {
            var histories = _service.GetPatientsHistories(patientId);
            return Ok(histories);
        }

        [HttpPost]
        public IActionResult AddHistory([FromBody] MedicalHistoryDto history)
        {
            try
            {
                _service.AddHistory(history);
                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateHistory([FromBody] MedicalHistoryDto history)
        {
            try
            {
                _service.UpdateHistory(history);
                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteHistory(Guid id)
        {
            var result = await _service.DeleteHistory(id);
            return result ? Ok() : NotFound($"History with Id {id} does not exist.");
        }
    }
}
