using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IGroupStudentRepository : IBaseRepository<GroupStudents>
    {
        Task<GroupStudents> GetByIdWithIncludeAsync(int? groupId, int? studentId);
    }
}
