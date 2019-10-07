using AR.College.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AR.College.Business.Interface
{
    public interface IDepartmentService
    {
        Task<Department> AddAsync(Department department);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department> GetAsync(int id);
        Task<bool> UpdateAsync(int id, Department department);
    }
}
