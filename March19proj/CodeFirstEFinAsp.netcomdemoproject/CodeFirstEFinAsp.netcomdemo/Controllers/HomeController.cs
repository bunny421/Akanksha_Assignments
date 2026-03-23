using CodeFirstEFinAsp.netcomdemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeFirstEFinAsp.netcomdemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EventContext _context;
        public HomeController(ILogger<HomeController> logger,EventContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult displayemp()
        {
            var employees = _context.employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee) 
        {
            if (ModelState.IsValid)
            {
                _context.employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("displayemp");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.employees.Find(id);
            if (employee == null)
            {
                return BadRequest();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("displayemp");
            }
            return View(employee);
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
