using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Infastrcuture
{
    public class StudentMap:EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            HasKey(m => m.Id);
        }
    }
}
