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
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Group>> GetAllWithAsync()
        {
            var data = await _context.Groups.AsNoTracking().Include(m => m.GroupStudents).Include(m => m.Education).Include(m => m.Room).ToListAsync();
            return data;
        }

        public async Task<Group> GetByIdWithAsync(int? id)
        {
            var data = await _context.Groups.AsNoTracking().Include(m => m.GroupStudents).Include(m => m.Education).Include(m => m.Room).FirstOrDefaultAsync(m => m.Id == id);
            return data;
        }

    }
}
