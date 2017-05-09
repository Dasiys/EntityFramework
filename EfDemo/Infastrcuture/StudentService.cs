using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Infastrcuture
{
    public class StudentService
    {
        private readonly StudentDbContext StudentDbContext;

        public StudentService(StudentDbContext studentDbContext)
        {
            StudentDbContext = studentDbContext;
        }


        /// <summary>
        /// 设置或获取学生
        /// </summary>
        /// <returns></returns>
        public IQueryable<Student> GetStudent()
        {
            return StudentDbContext.Set<Student>().Include("Subjects,Grades").AsNoTracking();
        }

        public void EditStudent(Student entity)
        {
            StudentDbContext.Set<Student>().Attach(entity);
            StudentDbContext.Entry(entity).State=EntityState.Modified;
            StudentDbContext.SaveChanges();
        }

        public void AddStudent(Student entity)
        {
            StudentDbContext.Set<Student>().Attach(entity);
            StudentDbContext.Entry(entity).State=EntityState.Added;
            StudentDbContext.SaveChanges();
        }
    }
}
