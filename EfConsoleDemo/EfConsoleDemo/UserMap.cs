using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleDemo
{
    public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(m => m.Id);
            Map<User>(pp => pp.Requires("Type").HasValue(0));
            Map<Student>(pp => pp.Requires("Type").HasValue(1));
            Map<Adult>(pp => pp.Requires("Type").HasValue(2));
        }

    }
}
