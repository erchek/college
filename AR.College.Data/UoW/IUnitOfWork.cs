using AR.College.Data.Models;
using AR.College.Data.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.College.Data.UoW
{
    public interface IUnitOfWork
    {
        IRepository<Department> DepartmentRepo { get; }
        IRepository<Faculty> FacultyRepo { get; }
        IRepository<Course> CourseRepo { get; }
        IRepository<Student> StudentRepo { get; }
    }
}
