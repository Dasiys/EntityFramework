using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Infastrcuture
{
    public class GradeService
    {
        private readonly StudentDbContext _studentDbContext;

        public GradeService(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        //public IQueryable<Grade> All()
        //{
        //    return _studentDbContext.Set<Grade>().AsNoTracking();
        //}

        public void AddGrade(Grade entity)
        {
            _studentDbContext.Set<Grade>().Attach(entity);
            _studentDbContext.Entry(entity).State=EntityState.Added;
        }
    }
}
