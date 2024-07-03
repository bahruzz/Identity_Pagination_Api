using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Student>> GetAllWithAsync()
        {
            var students = await _context.Students
            .Include(s => s.GroupStudents)
            .ThenInclude(gs => gs.Group)
            .ToListAsync();


            return students;
        }

        public async Task<Student> GetByIdWithAsync(int? id)
        {
            if (id == null) { throw new ArgumentNullException(nameof(id)); }
            var data = await _context.Students.AsNoTracking().Include(m => m.GroupStudents).ThenInclude(m => m.Group).FirstOrDefaultAsync(m => m.Id == id);
            return data;
        }
    }
}
