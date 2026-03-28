using Microsoft.AspNetCore.Mvc;
using ProductMVC.Models;
using System.Text;
using System.Text.Json;

namespace ProductMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _client;

        public ProductController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7099/");
        }

        // GET: Show all products
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("api/Product");
            var data = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<Product>>(data, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(products);
        }

        // GET: Add form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Add product
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _client.PostAsync("api/Product", content);

            return RedirectToAction("Index");
        }
    }
}