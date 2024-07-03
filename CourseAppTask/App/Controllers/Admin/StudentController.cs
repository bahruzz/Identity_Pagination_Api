using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Rooms;
using Service.DTOs.Admin.Students;
using Service.Services;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentCreateDto request)
        {
            await _studentService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { Response = "Succesfull" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mappedStudents = await _studentService.GetAllWithInclude();
            return Ok(mappedStudents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _studentService.GetByIdAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery] int id, [FromBody] StudentEditDto request)
        {
            await _studentService.EditAsync(id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _studentService.DeleteAsync(id);
            return Ok();
        }
    }
}
