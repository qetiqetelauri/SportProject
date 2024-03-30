using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectDTO;

namespace ProjectClient.Controllers
{
    public class StudentController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7062/api/students";

        public StudentController()
        {

            _httpClient = new HttpClient(); 
        }
        // GET: studentController1
        public async Task<ActionResult> Index()
        {
            var json = await _httpClient.GetStringAsync(_baseUrl);
            var studentList = JsonConvert.DeserializeObject<List<StudentDTO>>(json);
            ViewData["Title"] = "StudentPage";
            return View(studentList);
        }

        // GET: studentController1/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var json = await _httpClient.GetStringAsync(_baseUrl+"/"+id);
            var student = JsonConvert.DeserializeObject<StudentDTO>(json);
            return View(student);
        }

        // GET: studentController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: studentController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentDTO collection)
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

        // GET: studentController1/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var json = await _httpClient.GetStringAsync(_baseUrl + "/" + id);
            var student = JsonConvert.DeserializeObject<StudentDTO>(json);
            return View(student);
        }

        // POST: studentController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StudentDTO collection)
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

        // GET: studentController1/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var json = await _httpClient.GetStringAsync(_baseUrl + "/" + id);
            var student = JsonConvert.DeserializeObject<StudentDTO>(json);
            return View(student);
        }

        // POST: studentController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, StudentDTO collection)
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
