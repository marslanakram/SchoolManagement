using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;
using SchoolManagement.Service.EnrollmentService;

namespace SchoolManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentservice;

        public EnrollmentController(IEnrollmentService enrollmentservice)
        {
            _enrollmentservice = enrollmentservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enrollments = await _enrollmentservice.GetAllAsync();
            return Ok(enrollments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var enrollment = await _enrollmentservice.GetByIdAsync(id);
            if (enrollment == null) return NotFound();
            return Ok(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnrollmentDto dto)
        {
            var created = await _enrollmentservice.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EnrollmentDto dto)
        {
            var updated = await _enrollmentservice.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _enrollmentservice.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
