using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    /// <summary>
    /// 学生科目关联
    /// </summary>
    public class StudentSubjectMap:EntityBbase
    {
        /// <summary>
        /// 设置或获取学生Id
        /// </summary>
        public int StudentId { set; get; }
        /// <summary>
        /// 设置或获取学科Id
        /// </summary>
        public  int SubjectId { set; get; }

        /// <summary>
        /// 设置或获取学生信息
        /// </summary>
        public virtual Student Student { set; get; }

        /// <summary>
        /// 设置或获取学科信息
        /// </summary>
        public virtual Subject Subject { set; get; }
    }
}
