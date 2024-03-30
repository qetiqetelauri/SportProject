using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectDTO;

namespace ProjectClient.Controllers
{
    public class CustomerController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7062/api/customers";

        public CustomerController()
        {

            _httpClient = new HttpClient(); 
        }
        // GET: CustomerController1
        public async Task<ActionResult> Index()
        {
            var json = await _httpClient.GetStringAsync(_baseUrl);
            var customerList = JsonConvert.DeserializeObject<List<CustomerDTO>>(json);
            ViewData["Title"] = "CustomerPage";
            return View(customerList);
        }

        // GET: CustomerController1/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var json = await _httpClient.GetStringAsync(_baseUrl+"/"+id);
            var customer = JsonConvert.DeserializeObject<CustomerDTO>(json);
            return View(customer);
        }

        // GET: CustomerController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerDTO collection)
        {
            try
            {
                await _httpClient.PostAsJsonAsync(_baseUrl, collection);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController1/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var json = await _httpClient.GetStringAsync(_baseUrl + "/" + id);
            var customer = JsonConvert.DeserializeObject<CustomerDTO>(json);
            return View(customer);
        }

        // POST: CustomerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CustomerDTO collection)
        {
            try
            {
                await _httpClient.PutAsJsonAsync(_baseUrl + "/" + id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController1/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var json = await _httpClient.GetStringAsync(_baseUrl + "/" + id);
            var customer = JsonConvert.DeserializeObject<CustomerDTO>(json);
            return View(customer);
        }

        // POST: CustomerController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, CustomerDTO collection)
        {
            try
            {
                await _httpClient.DeleteAsync(_baseUrl + "/" + id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
