using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AR.College.Business.Interface;
using AR.College.Data.Context;
using AR.College.Data.Models;using AR.College.Data.UoW;
using Microsoft.EntityFrameworkCore;

namespace AR.College.Business.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly CollegeDbContext _context;
        public DepartmentService(CollegeDbContext context)
        {
            _context = context;
        }

        public async Task<Department> AddAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return false;
            }

            _context.Departments.Remove(department);
            int saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            await Task.FromResult(0);
            return _context.Departments;
        }

        public async Task<Department> GetAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Department department)
        {
            if (id != department.Id)
            {
                return false;
            }
            _context.Entry(department).State = EntityState.Modified;
            int saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
