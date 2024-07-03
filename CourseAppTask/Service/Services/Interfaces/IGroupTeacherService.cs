using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.GroupTeachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupTeacherService
    {
        Task CreateAsync(GroupTeacherCreateDto model);
        Task EditAsync(int? id, GroupTeacherEditDto model);
        Task DeleteAsync(int? groupId, int? teacherId);
    }
}
