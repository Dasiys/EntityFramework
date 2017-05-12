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
        public string Name { set; get; }
        /// <summary>
        /// 设置或获取并发
        /// </summary>
        public byte[] RowStamp { set; get; }
    }
}
