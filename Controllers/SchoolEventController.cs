using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.Dto;
using SchoolManagement.Service.SchoolEventService;

namespace SchoolManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolEventController : ControllerBase
    {
        private readonly ISchoolEventService _schoolEventService;

        public SchoolEventController(ISchoolEventService schoolEventService)
        {
            _schoolEventService = schoolEventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _schoolEventService.GetAllAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var schoolEvent = await _schoolEventService.GetByIdAsync(id);
            if (schoolEvent == null) return NotFound();
            return Ok(schoolEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SchoolEventDto dto)
        {
            var created = await _schoolEventService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SchoolEventDto dto)
        {
            var updated = await _schoolEventService.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _schoolEventService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
