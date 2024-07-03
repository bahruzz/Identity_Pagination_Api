using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GroupTeacherRepository : BaseRepository<GroupTeachers>, IGroupTeacherRepository
    {
        public GroupTeacherRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<GroupTeachers> GetByIdWithIncludeAsync(int? groupId, int? teacherId)
        {
            return await _context.GroupTeachers.Include(m => m.Group).Include(m => m.Teacher).FirstOrDefaultAsync(m => m.GroupId == groupId&& m.TeacherId==teacherId);
        }
    }
}
