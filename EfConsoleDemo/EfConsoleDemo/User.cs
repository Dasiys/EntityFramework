using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleDemo
{
    public class User
    {
        public int Id { set; get; }
        [StringLength(7)]
        public string Name { set; get; }
    }
}
