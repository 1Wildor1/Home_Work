using Home_Work.DAL.Infrastructure;
using Home_Work.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Home_Work.DAL.Controllers
{
    public class StudentActionController : Controller
    {
        private readonly IStudentInterface repository;
        public StudentActionController(IStudentInterface repository)
        {
            this.repository = repository;
        }

        public HttpResponse GetStudent()
        {
            string obgjson = System.Text.Json.JsonSerializer.Serialize(repository.Select());

            return View();
        }
    }
}