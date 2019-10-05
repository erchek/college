using AR.College.Data.Context;
using AR.College.Data.Models;
using AR.College.Data.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AR.College.Data.UoW
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly CollegeDbContext _context = null;


        private IRepository<Department> _departmentRepo;
        private IRepository<Faculty> _facultyRepo;
        private IRepository<Course> _courseRepo;
        private IRepository<Student> _studentRepo;

        public UnitOfWork(CollegeDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public IRepository<Department> DepartmentRepo
        {
            get
            {
                if (this._departmentRepo == null)
                    this._departmentRepo = new Repository<Department>(_context);
                return _departmentRepo;
            }
        }

        public IRepository<Faculty> FacultyRepo
        {
            get
            {
                if (this._facultyRepo == null)
                    this._facultyRepo = new Repository<Faculty>(_context);
                return _facultyRepo;
            }
        }

        public IRepository<Course> CourseRepo
        {
            get
            {
                if (this._courseRepo == null)
                    this._courseRepo = new Repository<Course>(_context);
                return _courseRepo;
            }
        }

        public IRepository<Student> StudentRepo
        {
            get
            {
                if (this._studentRepo == null)
                    this._studentRepo = new Repository<Student>(_context);
                return _studentRepo;
            }
        }
    }
}
