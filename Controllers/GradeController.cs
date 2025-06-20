using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.Dto;
using SchoolManagement.Data.Entities;
using SchoolManagement.Service.GradeService;

namespace SchoolManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grades = await _gradeService.GetAllAsync();
            return Ok(grades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var grade = await _gradeService.GetByIdAsync(id);
            if (grade == null) return NotFound();
            return Ok(grade);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GradeDto dto)
        {
            var created = await _gradeService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GradeDto dto)
        {
            var updated = await _gradeService.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _gradeService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
