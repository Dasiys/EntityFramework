using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Infastrcuture;

namespace EfDemo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly StudentDbContext StudentDbContext=new StudentDbContext();
        private readonly StudentService _studentService=new StudentService(StudentDbContext);
        private readonly SubjectService _subjectService=new SubjectService(StudentDbContext);
        private readonly GradeService _gradeService=new GradeService(StudentDbContext);
        public ActionResult Index()
        {
            var student = _studentService.GetStudent().ToList();
            ViewBag.Student = student;
            ViewBag.Subject = _subjectService.All().ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}