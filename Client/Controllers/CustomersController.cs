
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Client.ViewModels;
using System.Text;
using Microsoft.AspNetCore.Http;
using System;

namespace Client.Controllers
{
    public class CustomersController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";

        public CustomersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:44370/api/Customers";
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, ProductApiUrl);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string strData = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<List<Customer>>(strData, options);
                return View(data);
            }
            return RedirectToAction("Error", "Home", null);
        }

        //CURD HERE
        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var jsonCustomer = JsonSerializer.Serialize(customer);
                var content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(ProductApiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle the error response here
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the customer.");
                }
            }

            return View(customer);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSelected(List<string> selectedUsernames)
        {
            foreach (var username in selectedUsernames)
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"{ProductApiUrl}/Delete/{username}");
                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    // Handle the error response if needed
                    ModelState.AddModelError(string.Empty, $"Failed to delete customer {username}.");
                }
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Error", "Home", null);
            }
        }
    }
}

