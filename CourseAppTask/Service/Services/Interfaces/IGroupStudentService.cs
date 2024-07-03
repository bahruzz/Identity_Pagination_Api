using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.GroupStudents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupStudentService
    {
        Task CreateAsync(GroupStudentCreateDto model);
        Task EditAsync(int? id, GroupStudentEditDto model);
        Task DeleteAsync(int? groupId, int? studentId);
    }
}
