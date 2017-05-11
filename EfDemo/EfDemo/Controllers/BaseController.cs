using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace EfDemo.Controllers
{
    public class BaseController : Controller
    {
        protected ActionResult TryScope(Func<ActionResult> func)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var result = func();
                    scope.Complete();
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}