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
    public class StudentService : IStudentService
    {
        private readonly CollegeDbContext _context;
        public StudentService(CollegeDbContext context)
        {
            _context = context;
        }

        public async Task<Student> AddAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return false;
            }

            _context.Students.Remove(student);
            int saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            await Task.FromResult(0);
            return _context.Students;
        }

        public async Task<Student> GetAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Student student)
        {
            if (id != student.Id)
            {
                return false;
            }
            _context.Entry(student).State = EntityState.Modified;
            int saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
