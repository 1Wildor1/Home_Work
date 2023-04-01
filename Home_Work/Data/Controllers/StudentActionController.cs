using Home_Work.DAL.Infrastructure;
using Home_Work.DAL.Repositories;
using System.Web.Mvc;

namespace Home_Work.DAL.Controllers
{
    public class StudentActionController : Controller
    {
        private readonly IRepositoryInterface repository;

        public StudentActionController(IRepositoryInterface repository)
        {
            this.repository = repository;
        }


        public ActionResult GetStudent()
        {

            string obgjson = System.Text.Json.JsonSerializer.Serialize(repository.Select());

            ViewBag.Student = obgjson;

            return View();
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(string name, string lastname, string yearOfStudy)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(yearOfStudy))
            {
                TempData["SM"] = "не удалось создать Студента!";
            }
            else
            {
                repository.CreateNewStudent(name, lastname, yearOfStudy);
                TempData["SM"] = "Вы создали Студента!";
            }

            return View();
        }
    }
}