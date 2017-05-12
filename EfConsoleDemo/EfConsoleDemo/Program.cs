using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
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
            #region 测试继承的TPH模式
            //try
            //{
            //    using (var scope = new TransactionScope())
            //    {
            //        using (var db = new UserContext())
            //        {
            //            var user = db.User;
            //            user.Add(new User()
            //            {
            //                Name = "叶伟密"
            //            });
            //            db.SaveChanges();
            //            var userCount = db.User.Count();
            //            Console.WriteLine("用户数目:{0}",userCount);
            //        }

            //        using (var db = new UserContext())
            //        {
            //            db.User.Add(new User()
            //            {
            //                Name = "小花"
            //            });
            //            db.SaveChanges();
            //        }
            //        scope.Complete();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //using (var db=new UserContext())
            //{
            //    var user = db.Set<User>();
            //    user.Add(new Student()
            //    {
            //        Name = "学生",
            //        School = "杭州师范大学"
            //    });
            //    user.Add(new Adult()
            //    {
            //        Name = "成人",
            //        Age = 18
            //    });
            //    db.SaveChanges();
            //    Console.WriteLine("最终用户数目:{0}",db.User.Count());
            //}
            #endregion
            #region 测试并发(有3种处理方案)

            var db1 = new UserContext();
            var db2 = new UserContext();
            try
            {
                var user1 = db1.Set<User>().SingleOrDefault(m => m.Id == 1);
                user1.Name = "测89";
                var user2 = db2.Set<User>().SingleOrDefault(m => m.Id == 1);
                user2.Name = "测235";
                db2.SaveChanges();
                db1.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // 策略一，保存user2的值
                //ex.Entries.Single().Reload();
                //db1.SaveChanges();

                // 策略2，保存User1的值
                //var entry = ex.Entries.Single();
                //entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                //db1.SaveChanges();

                // 策略3，根据客户端决定
                var entry = ex.Entries.Single();
                var databaseValues = entry.GetDatabaseValues();
                var currentUser = (User) entry.CurrentValues.ToObject();
                var databaseUser = (User)databaseValues.ToObject();
                var resolveUser = (User) databaseValues.Clone().ToObject();
                Merge(currentUser,databaseUser,resolveUser);
                entry.OriginalValues.SetValues(databaseUser);
                entry.CurrentValues.SetValues(resolveUser);
                db1.SaveChanges();
            }
            Console.WriteLine(db1.Set<User>().SingleOrDefault(m => m.Id == 1).Name);
            Console.ReadLine();
            #endregion
        }

        public static void Merge(User currentUser, User databaseUser, User resolveUser)
        {
            Console.WriteLine("当前名字:{0}",currentUser.Name);
            Console.WriteLine("数据库名字:{0}",databaseUser.Name);
            resolveUser.Name = currentUser.Name + "Merged by user1";
        }
    }
}
