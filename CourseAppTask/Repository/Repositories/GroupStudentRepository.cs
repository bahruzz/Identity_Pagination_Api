using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class GroupStudentRepository : BaseRepository<GroupStudents>, IGroupStudentRepository
    {
        public GroupStudentRepository(AppDbContext context) : base(context)
        {
        }

       

        public async Task<GroupStudents> GetByIdWithIncludeAsync(int? groupId, int? studentId)
        {
            return await _context.GroupStudents.Include(m => m.Group).Include(m => m.Student).FirstOrDefaultAsync(m => m.GroupId == groupId && m.StudentId ==studentId);

        }
    }
}
