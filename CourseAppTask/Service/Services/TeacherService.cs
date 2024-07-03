using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Rooms;
using Service.DTOs.Admin.Teachers;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepo;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepo = teacherRepository;
            _mapper = mapper;
            
        }


        public async Task Create(TeacherCreateDto model)
        {
            await _teacherRepo.CreateAsync(_mapper.Map<Teacher>(model));
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _teacherRepo.GetById(id);
            await _teacherRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, TeacherEditDto model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _teacherRepo.GetByIdWithAsync(id);

            if (data is null) throw new ArgumentNullException();

            //_context.GroupTeachers.RemoveRange(data.GroupTeachers);
            //foreach (var groupId in model.GroupId)
            //{
            //    data.GroupTeachers.Add(new GroupTeacher { TeacherId = data.Id, GroupId = groupId });
            //}

            var editData = _mapper.Map(model, data);
            await _teacherRepo.EditAsync(editData);
        }

        public async  Task<IEnumerable<TeacherDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<TeacherDto>>(await _teacherRepo.GetAllAsync());

        }

        public async Task<TeacherDto> GetByIdAsync(int id)
        {
            return _mapper.Map<TeacherDto>(await _teacherRepo.GetByIdWithAsync(id));
        }
    }
}
