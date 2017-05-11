using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Win32;

namespace EfConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var db = new UserContext())
                    {
                        var user = db.User;
                        user.Add(new User()
                        {
                            Name = "叶伟密"
                        });
                        db.SaveChanges();
                        var userCount = db.User.Count();
                        Console.WriteLine("用户数目:{0}",userCount);
                    }

                    using (var db = new UserContext())
                    {
                        db.User.Add(new User()
                        {
                            Name = "小花999花花花花"
                        });
                        db.SaveChanges();
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            using (var db=new UserContext())
            {
                Console.WriteLine("最终用户数目:{0}",db.User.Count());
            }
            Console.ReadLine();
        }
    }
}
