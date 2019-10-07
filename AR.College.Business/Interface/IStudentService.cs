using AR.College.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AR.College.Business.Interface
{
    public interface IStudentService
    {
        Task<Student> AddAsync(Student student);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetAsync(int id);
        Task<bool> UpdateAsync(int id, Student student);
    }
}
