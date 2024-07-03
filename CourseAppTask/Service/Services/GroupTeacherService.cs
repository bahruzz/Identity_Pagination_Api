using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.GroupStudents;
using Service.DTOs.Admin.GroupTeachers;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupTeacherService : IGroupTeacherService
    {
        private readonly IGroupTeacherRepository _groupTeacherRepository;
        private readonly IMapper _mapper;

        public GroupTeacherService(IMapper mapper,
                            IGroupTeacherRepository groupTeacherRepository)
        {
            _mapper = mapper;
            _groupTeacherRepository = groupTeacherRepository;
        }
       


       
        public async Task CreateAsync(GroupTeacherCreateDto model)
        {
            await _groupTeacherRepository.CreateAsync(_mapper.Map<GroupTeachers>(model));
        }

        public async Task DeleteAsync(int? groupId,int ? teacherId)
        {
            var data=await _groupTeacherRepository.GetByIdWithIncludeAsync((int)groupId,(int)teacherId);
            await _groupTeacherRepository.DeleteAsync(data);
        }

      
        public async  Task EditAsync(int? id, GroupTeacherEditDto model)
        {
            var data = await _groupTeacherRepository.GetById((int)id);
            await _groupTeacherRepository.EditAsync(_mapper.Map(model,data));
        }
    }
}
