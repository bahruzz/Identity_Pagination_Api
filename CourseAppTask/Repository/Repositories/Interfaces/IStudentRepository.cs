using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<Student> GetByIdWithAsync(int? id);
        Task<IEnumerable<Student>> GetAllWithAsync();
    }
}
