using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Infastrcuture
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext() : base("StudentDb")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        static StudentDbContext()
        {
            System.Data.Entity.Database.SetInitializer<StudentDbContext>(null);
        }

        public DbSet<Grade> Grade { set; get; }
        public DbSet<Subject> Subject { set; get; }
        public  DbSet<Student> Student { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typeRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(
                    type =>
                        type.BaseType != null && type.BaseType.IsGenericType &&
                        type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typeRegister)
            {
                dynamic configurationInstance=Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
