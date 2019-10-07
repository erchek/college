using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AR.College.Business.Interface;
using AR.College.Data.Context;
using AR.College.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AR.College.Business.Implementation
{
    public class FacultyService : IFacultyService
    {
        private readonly CollegeDbContext _context;
        public FacultyService(CollegeDbContext context)
        {
            _context = context;
        }

        public async Task<Faculty> AddAsync(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            await _context.SaveChangesAsync();
            return faculty;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty == null)
            {
                return false;
            }

            _context.Faculties.Remove(faculty);
            int saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<IEnumerable<Faculty>> GetAllAsync()
        {
            await Task.FromResult(0);
            return _context.Faculties;
        }

        public async Task<Faculty> GetAsync(int id)
        {
            return await _context.Faculties.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Faculty faculty)
        {
            if (id != faculty.Id)
            {
                return false;
            }
            _context.Entry(faculty).State = EntityState.Modified;
            int saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
