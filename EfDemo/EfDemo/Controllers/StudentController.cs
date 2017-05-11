using Domain.Model;
using Infastrcuture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace EfDemo.Controllers
{
    public class StudentController : Controller
    {

        private readonly StudentService _studentService = new StudentService(new StudentDbContext());
        private readonly SubjectService _subjectService=new SubjectService(new StudentDbContext());
        // GET: Student
        public ActionResult Index()
        {
            var student = _studentService.All();
            ViewBag.Subject = GetSubjects();
            return View(student);
        }
        [HttpPost]
        public string Index(string subjectId,string pageSize)
        {
            var id = Convert.ToInt32(subjectId);
            var result = _studentService.GetPage(Convert.ToInt32(pageSize), m => m.Id,
                m => m.Subjects.Any(n => id == 0 || n.Id == id)).ToList();
            return JsonConvert.SerializeObject(result);
        }

        private IList<SelectListItem> GetSubjects()
        {
            var subjects= _subjectService.All().Select(_ => new SelectListItem()
            {
                Text = _.Name,
                Value = _.Id.ToString()
            }).ToList();
            subjects.Insert(0,new SelectListItem()
            {
                 Text = "全部",
                 Value = "0"
            });
            return subjects;
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
            var student = _studentService.All().FirstOrDefault(m => m.Id == studentId);
            ViewBag.Subject = _subjectService.All().ToList();
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(int Id, List<string> subjectId )
        {
            _studentService.EditStudentSubject(Id,subjectId);
            return RedirectToAction("Index", "Student");
        }
    }
}