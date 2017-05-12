using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleDemo
{
    public class Student:User
    {
        /// <summary>
        /// 设置或获取学校
        /// </summary>
        public string School { set; get; }
    }
}
