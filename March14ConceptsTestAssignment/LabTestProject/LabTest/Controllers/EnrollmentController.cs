using LabTest.Models;
using LabTest.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LabTest.Controllers
{
    public class EnrollmentController : Controller
    {
        private static List<Student> _students;
        private static List<Course> _courses;

        public EnrollmentController()
        {
            if (_courses == null)
            {
                _courses = new()
        {
            new() { CourseId = 1, Title = "Data Structures", Credits = 4, Department = "CSE" },
            new() { CourseId = 2, Title = "Algorithms", Credits = 4, Department = "CSE" },
            new() { CourseId = 3, Title = "Databases", Credits = 3, Department = "CSE" },
            new() { CourseId = 4, Title = "Web Dev", Credits = 3, Department = "IT" },
            new() { CourseId = 5, Title = "OS", Credits = 4, Department = "CSE" }
        };
            }

            if (_students == null)
            {
                _students = new()
        {
            new() { StudentId = 1, Name = "Alice", Branch = "CSE", Enrollments = new()
            {
                new() { CourseId = 1, Grade = "A", AttemptNumber = 1 },
                new() { CourseId = 2, Grade = "A-", AttemptNumber = 1 },
                new() { CourseId = 3, Grade = "B+", AttemptNumber = 1 }
            }},
            new() { StudentId = 2, Name = "Bob", Branch = "CSE", Enrollments = new()
            {
                new() { CourseId = 1, Grade = "B", AttemptNumber = 1 },
                new() { CourseId = 4, Grade = "A", AttemptNumber = 1 },
                new() { CourseId = 5, Grade = "B+", AttemptNumber = 1 }
            }}
        };
            }
        
        }

        // GET: EnrollmentController

        public IActionResult Index()
        {
            var studentCourses = _students
                .SelectMany(s => s.Enrollments.DefaultIfEmpty(), (s, e) => new StudentCoursesVM
                {
                    StudentId = s.StudentId,
                    StudentName = s.Name,
                    Branch = s.Branch,
                    CourseTitle = e != null ? _courses.FirstOrDefault(c => c.CourseId == e.CourseId)?.Title : "No Course",
                    Grade = e?.Grade,
                    AttemptNumber = e?.AttemptNumber ?? 0
                })
                .ToList();

            return View(studentCourses);
        }

        // GET: EnrollmentController/Details/5
        public IActionResult Details(int id)
        {
            var studentCourses = _students.Where(s => s.StudentId == id).SelectMany(s => s.Enrollments.Select(e => new StudentCoursesVM
            {
                StudentId = s.StudentId,
                StudentName = s.Name,
                Branch = s.Branch,
                CourseTitle = _courses.FirstOrDefault(c => c.CourseId == e.CourseId)?.Title,
                Grade = e.Grade,
                AttemptNumber = e.AttemptNumber
            }));
            return View(studentCourses);
        }

        // GET: EnrollmentController/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: EnrollmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                student.StudentId = _students.Max(s => s.StudentId) + 1;
                student.Enrollments = new List<Enrollment>();
                _students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: EnrollmentController/Edit/5
        public IActionResult Edit(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: EnrollmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student updatedStudent)
        {
            var student = _students.FirstOrDefault(s=>s.StudentId == updatedStudent.StudentId);
            if (student != null)
            {
                
                student.Name = updatedStudent.Name;

                student.Branch = updatedStudent.Branch;
            }
            return RedirectToAction("Index");
        }

        // GET: EnrollmentController/Delete/5
        public IActionResult Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: EnrollmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Student stu )
        {
            var student = _students.FirstOrDefault(s => s.StudentId == stu.StudentId);
            if (student != null)
            {
                 _students.Remove(student);
            }
            return RedirectToAction("Index");
        }
    }
}
