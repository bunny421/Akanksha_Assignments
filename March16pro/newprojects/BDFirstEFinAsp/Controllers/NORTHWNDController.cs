using Microsoft.AspNetCore.Mvc;
using BDFirstEFinAsp.Models;
namespace BDFirstEFinAsp.Controllers
{
    public class NORTHWNDController : Controller
    {
        public IActionResult SpainCustomers()
        {
            NorthWindContext cnt = new NorthWindContext();
            var spainCustomers = cnt.Customers
    .Where(x => x.Country == "Spain")
    .Select(x => new SpainCustomerViewModel
    {
        Cid = x.CustomerId,
        Cname = x.ContactName,
        Comname = x.CompanyName
    })
    .ToList();
            return View(spainCustomers);
        
    }
        public IActionResult SpainCustomers2()
        {
            NorthWindContext cnt = new NorthWindContext();
            var spainCustomers = cnt.Customers
    .Where(x => x.Country == "Spain")
    .Select(x => new SpainCustomerViewModel
    {
        Cid = x.CustomerId,
        Cname = x.ContactName,
        Comname = x.CompanyName
    })
    .ToList();
            return View(spainCustomers);

        }
        public IActionResult searchCustomer(string contactname)
        {
            NorthWindContext cnt = new NorthWindContext();
            var searchcustomer = from customer in cnt.Customers
                                 where customer.ContactName == contactname
                                 select new Customer
                                 {
                                     ContactName = customer.ContactName,
                                     ContactTitle = customer.ContactTitle,
                                     CompanyName = customer.CompanyName
                                 };
            var searchcustomer2 = cnt.Customers.Where(x => x.CompanyName == contactname).
                Select(x => new Customer { ContactName = x.ContactName, ContactTitle = x.ContactTitle, CompanyName = x.CompanyName });
            var query1 = searchcustomer.Single();
            var query2 = searchcustomer2.Single();
            return View(query1);
        }

     }
}
