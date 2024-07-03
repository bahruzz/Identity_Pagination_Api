using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface ITeacherRepository:IBaseRepository<Teacher>
    {
        Task<Teacher> GetByIdWithAsync(int? id);
        Task<IEnumerable<Teacher>> GetAllWithAsync();
    }
}
