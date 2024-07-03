using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.GroupStudents;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupStudentService : IGroupStudentService
    {
        private readonly IGroupStudentRepository _groupStudentRepository;
        private readonly IGroupTeacherRepository _groupTeacherRepository;
        private readonly IMapper _mapper;

        public GroupStudentService(IGroupStudentRepository groupStudentRepository,
                            IMapper mapper,
                            IGroupTeacherRepository groupTeacherRepository)
        {
            _groupStudentRepository = groupStudentRepository;
            _mapper = mapper;
            _groupTeacherRepository = groupTeacherRepository;
        }
        public async Task CreateAsync(GroupStudentCreateDto model)
        {
            await _groupStudentRepository.CreateAsync(_mapper.Map<GroupStudents>(model));
        }

      

        public async Task DeleteAsync(int? groupId, int? studentId)
        {
            var data = await _groupStudentRepository.GetByIdWithIncludeAsync((int)groupId, (int)studentId);
            await _groupStudentRepository.DeleteAsync(data);
        }

        public async Task EditAsync(int? id, GroupStudentEditDto model)
        {
            var data=await _groupStudentRepository.GetById((int)id);

            await _groupStudentRepository.EditAsync(_mapper.Map(model, data));    
        }
    }
}
