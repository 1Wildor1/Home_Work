using Home_Work.DAL.Infrastructure;
using System.Net.Http;
using System.Web.Mvc;

namespace Home_Work.DAL.Controllers
{
    class StudentActionApiController : Controller
    {
        private readonly IStudentInterface repository;

        public StudentActionApiController(IStudentInterface repository)
        {
            this.repository = repository;
        }

        public HttpResponseMessage GetStudent()
        {

            string obgjson = System.Text.Json.JsonSerializer.Serialize(repository.Select());

            return View();
        }

    }
}