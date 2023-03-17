using Home_Work.DAL.Context;
using Home_Work.DAL.Models;
using Home_Work.DAL.Repositories;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Mvc;

namespace Home_Work.DAL.Controllers
{
        class StudentController : Controller
    {
        readonly StudentRepository repository;
        public StudentController(StudentRepository _repository)
        {
            repository = _repository;
        }
        [HttpGet]
        public string GetStudent()
        {

            string obgjson = System.Text.Json.JsonSerializer.Serialize(repository.Select());

            return View(obgjson);
        }

    }
}