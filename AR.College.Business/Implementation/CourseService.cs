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
    public class CourseService : ICourseService
    {
        private readonly CollegeDbContext _context;
        public CourseService(CollegeDbContext context)
        {
            _context = context;
        }

        public async Task<Course> AddAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return false;
            }

            _context.Courses.Remove(course);
            int saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            await Task.FromResult(0);
            return _context.Courses;
        }

        public async Task<Course> GetAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Course course)
        {
            if (id != course.Id)
            {
                return false;
            }
            _context.Entry(course).State = EntityState.Modified;
            int saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
