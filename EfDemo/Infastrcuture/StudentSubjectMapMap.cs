using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Infastrcuture
{
    public class StudentSubjectMapMap:EntityTypeConfiguration<StudentSubjectMap>
    {
        public StudentSubjectMapMap()
        {
            HasKey(m => m.Id);
            HasRequired(m => m.Subject).WithMany(n => n.Students).HasForeignKey(m => m.SubjectId);
            HasRequired(m => m.Student).WithMany(n => n.Subjects).HasForeignKey(m => m.StudentId);
        }
    }
}
