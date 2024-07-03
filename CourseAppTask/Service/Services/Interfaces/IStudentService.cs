using Service.DTOs.Admin.Students;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Task CreateAsync(StudentCreateDto model);
        Task<IEnumerable<StudentDto>> GetAllWithInclude();

        Task<StudentDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);

        Task EditAsync(int id, StudentEditDto model);
    }
}
