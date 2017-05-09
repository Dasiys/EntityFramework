using Domain.Model;
using Infastrcuture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _stidentService=new StudentService(new StudentDbContext());
        // GET: Student
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Student entity)
        {
            if(ModelState.IsValid)
                _stidentService.AddStudent(entity);
            return View();
        }
    }
}