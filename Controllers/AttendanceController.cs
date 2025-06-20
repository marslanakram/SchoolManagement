using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;
using SchoolManagement.Service.AttendanceService;

namespace SchoolManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceservice;

        public AttendanceController(IAttendanceService attendanceservice)
        {
            _attendanceservice = attendanceservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var attendances = await _attendanceservice.GetAllAsync();
            return Ok(attendances);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var attendance = await _attendanceservice.GetByIdAsync(id);
            if (attendance == null) return NotFound();
            return Ok(attendance);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AttendanceDto dto)
        {
            var created = await _attendanceservice.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AttendanceDto dto)
        {
            var updated = await _attendanceservice.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _attendanceservice.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
