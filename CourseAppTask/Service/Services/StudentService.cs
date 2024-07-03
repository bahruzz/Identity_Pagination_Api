using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Students;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IGroupStudentRepository _groupStudentRepo;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepo,
                              IGroupStudentRepository groupStudentRepo,
                              IMapper mapper)
        {
            _studentRepo = studentRepo;
            _groupStudentRepo = groupStudentRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(StudentCreateDto model)
        {
            var data = _mapper.Map<Student>(model);
            await _studentRepo.CreateAsync(data);

            foreach (var id in model.GroupIds)
            {
                await _groupStudentRepo.CreateAsync(new GroupStudents
                {
                    StudentId = data.Id,
                    GroupId = id
                });
            }
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _studentRepo.GetById(id);

            
            await _studentRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, StudentEditDto model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _studentRepo.GetByIdWithAsync(id);

            if (data is null) throw new NotFoundException("Student not found");

           
            var editData = _mapper.Map(model, data);
            await _studentRepo.EditAsync(editData);
        }

        public async Task<IEnumerable<StudentDto>> GetAllWithInclude()
        {
           var students =  await _studentRepo.FindAllWithIncludes()
                .Include(m => m.GroupStudents)
                .ThenInclude(m=>m.Group)
                .ToListAsync();
            var mappedStudents = _mapper.Map<List<StudentDto>>(students);
            return mappedStudents;
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            return _mapper.Map<StudentDto>(await _studentRepo.GetByIdWithAsync(id));
        }
    }
}
