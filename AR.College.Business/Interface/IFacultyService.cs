using AR.College.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AR.College.Business.Interface
{
    public interface IFacultyService
    {
        Task<Faculty> AddAsync(Faculty faculty);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Faculty>> GetAllAsync();
        Task<Faculty> GetAsync(int id);
        Task<bool> UpdateAsync(int id, Faculty faculty);
    }
}
