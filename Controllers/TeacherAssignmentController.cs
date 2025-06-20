using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.Dto;
using SchoolManagement.Service.TeacherAssignmentService;

namespace SchoolManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherAssignmentController : ControllerBase
    {
        private readonly ITeacherAssignmentService _teacherAssignmentService;

        public TeacherAssignmentController(ITeacherAssignmentService teacherAssignmentService)
        {
            _teacherAssignmentService = teacherAssignmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assignments = await _teacherAssignmentService.GetAllAsync();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var assignment = await _teacherAssignmentService.GetByIdAsync(id);
            if (assignment == null) return NotFound();
            return Ok(assignment);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeacherAssignmentDto dto)
        {
            var created = await _teacherAssignmentService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TeacherAssignmentDto dto)
        {
            var updated = await _teacherAssignmentService.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _teacherAssignmentService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
