using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Infastrcuture
{
    public class GradeMap:EntityTypeConfiguration<Grade>
    {
        public GradeMap()
        {
            HasKey(m => m.Id);
            HasRequired(m => m.Student).WithMany(n => n.Grades).HasForeignKey(n => n.StudentId);
        }
    }
}
