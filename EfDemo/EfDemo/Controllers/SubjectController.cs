using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Model;
using Infastrcuture;

namespace EfDemo.Controllers
{
    public class SubjectController : Controller
    {
        private static readonly  StudentDbContext StudentDbContext=new StudentDbContext(); 
        private  readonly SubjectService _subjectService=new SubjectService(StudentDbContext);
        // GET: Subject
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View(new Subject());
        }

        [HttpPost]
        public ActionResult Add(Subject entity)
        {
            _subjectService.AddSubject(entity);
            return RedirectToAction("Index", "Home");
        }
    }
}