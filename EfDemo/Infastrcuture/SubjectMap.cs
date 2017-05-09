using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastrcuture
{
    public class SubjectMap: EntityTypeConfiguration<Subject>
    {
        public SubjectMap()
        {
            HasKey(m => m.Id);
            HasMany(m => m.Grades).WithRequired(n => n.Subject).HasForeignKey(p => p.SubjectId);
        }
    }
}
