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
            var student = _studentService.GetStudent().ToList();
            ViewBag.Subject = GetSubjects();
            return View(student);
        }
        [HttpPost]
        public ActionResult Index(string subjectId)
        {
            var id = Convert.ToInt32(subjectId);
            var student = _studentService.Fetch(m => m.Subjects.Any(n => n.Id ==id)).ToList();
            ViewBag.Subject = GetSubjects();
            return View(student);
        }

        private IList<SelectListItem> GetSubjects()
        {
            return _subjectService.All().Select(_ => new SelectListItem()
            {
                Text = _.Name,
                Value = _.Id.ToString()
            }).ToList();
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