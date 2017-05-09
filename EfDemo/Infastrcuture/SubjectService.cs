using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastrcuture
{
    public class SubjectService
    {
        private readonly StudentDbContext _studentDbContext;

        public SubjectService(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        /// <summary>
        /// 添加所有课程
        /// </summary>
        /// <returns></returns>
        public IQueryable<Subject> All()
        {
            return _studentDbContext.Set<Subject>().AsNoTracking();
        }

        /// <summary>
        /// 添加课程目录
        /// </summary>
        /// <param name="entity"></param>
        public void AddSubject(Subject entity)
        {
            _studentDbContext.Set<Subject>().Attach(entity);
            _studentDbContext.Entry(entity).State=EntityState.Added;
        }
    }
}
