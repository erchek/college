using AR.College.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AR.College.Business.Interface
{
    public interface ICourseService
    {
        Task<Course> AddAsync(Course course);
        Task<bool> DeleteAsync(int id); 
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetAsync(int id);
        Task<bool> UpdateAsync(int id, Course course);
    }
}
