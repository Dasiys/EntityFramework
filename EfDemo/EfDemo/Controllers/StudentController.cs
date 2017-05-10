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

        private readonly StudentService _studentService = new StudentService(new StudentDbContext());
        private readonly SubjectService _subjectService=new SubjectService(new StudentDbContext());
        // GET: Student
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Add()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Add(Student entity)
        {
            if (ModelState.IsValid)
                _studentService.AddStudent(entity);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int studentId)
        {
            var student = _studentService.GetStudent().FirstOrDefault(m => m.Id == studentId);
            ViewBag.Subject = _subjectService.All().ToList();
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(int Id, List<string> subjectId )
        {
            _studentService.EditStudentSubject(Id,subjectId);
            return RedirectToAction("Index", "Home");
        }
    }
}