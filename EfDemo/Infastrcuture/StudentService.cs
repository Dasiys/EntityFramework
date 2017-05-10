using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Infastrcuture
{
    public class StudentService
    {
        private readonly StudentDbContext _studentDbContext;
        private readonly SubjectService _subjectService;
        public StudentService(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
            _subjectService = new SubjectService(_studentDbContext);
        }

        public IQueryable<Student> Fetch(Expression<Func<Student, bool>> param)
        {
            return GetStudent().Where(param);
        }

        /// <summary>
        /// 设置或获取学生
        /// </summary>
        /// <returns></returns>
        public IQueryable<Student> GetStudent()
        {
            return _studentDbContext.Set<Student>().Include(m=>m.Subjects).AsNoTracking();
        }

        public void EditStudent(Student entity)
        {
            _studentDbContext.Set<Student>().Attach(entity);
            _studentDbContext.Entry(entity).State = EntityState.Modified;
            _studentDbContext.SaveChanges();
        }

        /// <summary>
        /// 获得分页后的数据
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="orderBy"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public IQueryable<Student> GetPage(int pagesize, Expression<Func<Student, Type>> orderBy,
            Expression<Func<Student, bool>> param)
        {
            return this.Fetch(param).OrderBy(orderBy).Skip((pagesize - 1) * 2).Take(2);
        }

        public void EditStudentSubject(int studentId, List<string> subjectId)
        {
            var students = _studentDbContext.Set<Student>();
            var entity = students.FirstOrDefault(m => m.Id == studentId);
            if (entity != null)
            {
                students.Attach(entity);
                var entry = _studentDbContext.Entry(entity);
                entry.Property(m => m.FlowerNum).IsModified = true;
                entity.Subjects.Clear();
                entity.Subjects = _subjectService.All().Where(m => subjectId.Contains(m.Id.ToString())).ToList();
                _studentDbContext.SaveChanges();
            }
        }

        public void AddStudent(Student entity)
        {
            _studentDbContext.Set<Student>().Attach(entity);
            _studentDbContext.Entry(entity).State = EntityState.Added;
            _studentDbContext.SaveChanges();
        }
    }
}
