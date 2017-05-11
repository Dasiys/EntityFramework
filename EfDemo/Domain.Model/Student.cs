using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Student:EntityBbase
    {
        /// <summary>
        /// 设置姓名
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 设置编码
        /// </summary>
        public  string No { set; get; }
        /// <summary>
        /// 设置鲜花数目
        /// </summary>
        public  string FlowerNum { set; get; }
        /// <summary>
        /// 设置或获取成绩
        /// </summary>
        public virtual ICollection<Grade> Grades { set; get; }=new List<Grade>();
        /// <summary>
        /// 设置或获取成绩
        /// </summary>
        public virtual ICollection<Subject> Subjects { set; get; }=new List<Subject>();
    }
}
