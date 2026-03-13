using Microsoft.AspNetCore.Mvc;
using MVCexample1.Models;
using System.Diagnostics;

namespace MVCexample1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string sampledemo1()
        {
            return "Akku";
        }
        public string sampledemo2(int age , string name)
        {
            return "The name "+ name +"and having age +"+ age;
        }
        public IActionResult sampledemo3()
        {
            int age = 24;
            string name = "Akanksha";
            ViewBag.Age = age;
            ViewBag.Name = name;
            ViewData["Message"] = "Welcome to the world of magic and miracles";
            ViewData["Year"] = DateTime.Now.Year;
            return View();
        }
        Employee obj = new Employee()
        {
            EmployeeId = 1,
            EmpName = "Akanksha Kumari",
            Salary = 2000000
        };
        public IActionResult Details(int id)
        {
            var employee = emplist.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        List<Employee> emplist = new List<Employee>()
        {
            new Employee {EmployeeId =101 , EmpName ="Anki",Salary = 2000000 ,ImageUrl ="/images/image2.jpg",DeptID=30},
            new Employee {EmployeeId =102 , EmpName ="Adi",Salary = 2000000 ,ImageUrl ="/images/image3.jpg",DeptID=20},
            new Employee {EmployeeId =103 , EmpName ="Akshat",Salary = 2000000 ,ImageUrl ="/images/image2.jpg",DeptID=10},
            new Employee {EmployeeId =104 , EmpName ="Ankit",Salary = 2000000 ,ImageUrl ="/images/image3.jpg", DeptID = 10},

        };
        
        List<Dept> deptlist = new List<Dept>()
     {
         new Dept{DeptID=10,DeptName="Sales"},
         new Dept{DeptID=20,DeptName="HR"},
         new Dept{DeptID=30,DeptName="Software"}
     };
        public IActionResult collectionofdepts()
        {
            return View(deptlist);
        }
        public IActionResult EmpsInDept(int deptid)
        {
            var employees = emplist.Where(e => e.DeptID == deptid).ToList();
            return View(employees);
        }
        public IActionResult mixedobjectpassing(int empid)
        {
            var query1 = deptlist.ToList();
            Employee emp = emplist.Where(x=>x.EmployeeId == empid).FirstOrDefault();
            var query2 = emp;
            EmpdeptViewModel obj = new EmpdeptViewModel()
            {
                deptlist = query1,
                emp = query2,
                date = DateTime.Now
            };
            return View(obj);
        }
        
        public IActionResult searchemp(int id)
        {
            Employee employee = (from e1 in emplist where 
                                e1.EmployeeId==id select e1).FirstOrDefault();
            return View(employee);
        }
        public IActionResult display()
        {
            return View();
        }
        public IActionResult collectionofobjectpassinng()
        {
            return View(emplist);
        }
        public  IActionResult singleobjectpassing()
        {

            return View(obj);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
