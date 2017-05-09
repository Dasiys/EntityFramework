using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Grade:EntityBbase
    {
        /// <summary>
        /// 设置或获取学生
        /// </summary>
        public virtual Student Student { set; get; }

        /// <summary>
        /// 设置或获取学科
        /// </summary>
        public virtual Subject Subject { set; get; }

        /// <summary>
        /// 设置或获取学生Id
        /// </summary>
        public int StudentId { set; get; }

        /// <summary>
        /// 设置或获取学科Id
        /// </summary>
        public  int SubjectId { set; get; }

        /// <summary>
        /// 设置或获取成绩
        /// </summary>
        public decimal Score { set; get; }
    }
}
