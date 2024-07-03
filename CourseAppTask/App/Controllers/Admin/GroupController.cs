using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.GroupStudents;
using Service.DTOs.Admin.GroupTeachers;
using Service.DTOs.Admin.Rooms;
using Service.Services;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace App.Controllers.Admin
{
    public class GroupController : BaseController
    {
        private readonly IGroupService _groupService;
        private readonly IGroupTeacherService _groupTeacherService;
        private readonly IGroupStudentService _groupStudentService;

        public GroupController(IGroupService groupService, 
                               IGroupTeacherService groupTeacherService, 
                               IGroupStudentService groupStudentService)
        {
            _groupService = groupService;
            _groupTeacherService = groupTeacherService;
            _groupStudentService = groupStudentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupCreateDto request)
        {
            await _groupService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { Response = "Successfull" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _groupService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _groupService.GetByIdAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery] int id, [FromBody] GroupEditDto request)
        {
            await _groupService.EditAsync(id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _groupService.DeleteAsync(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddTeacher([FromBody] GroupTeacherCreateDto request)
        {
            await _groupTeacherService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new {Response="Successfuly added teacher"});
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] GroupStudentCreateDto request)
        {
            await _groupStudentService.CreateAsync(request);
            return CreatedAtAction(nameof(Create) ,new { Response = "Successfuly added student" });
        }
        [HttpDelete]
        public async Task<IActionResult> TeacherDelete([FromBody] GroupTeacherCreateDto request)
        {
            
            await _groupTeacherService.DeleteAsync(request.GroupId,request.TeacherId);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> StudentDelete([FromBody][Required] GroupStudentCreateDto request)
        {

            await _groupStudentService.DeleteAsync(request.GroupId, request.StudentId);
            return Ok();
        }
       



    }
}
