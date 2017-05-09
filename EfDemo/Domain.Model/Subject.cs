using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    /// <summary>
    /// 学科
    /// </summary>
    public class Subject:EntityBbase
    {
        /// <summary>
        /// 设置或获取名称
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 设置或获取编号
        /// </summary>
        public string No { set; get; }
        /// <summary>
        /// 设置或获取成绩
        /// </summary>
        public virtual ICollection<Grade> Grades { set; get; }
        /// <summary>
        /// 设置或获取学生
        /// </summary>
        public virtual ICollection<StudentSubjectMap> Students { set; get; }
    }
}
