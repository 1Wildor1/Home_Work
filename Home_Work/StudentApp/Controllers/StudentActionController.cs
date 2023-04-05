using Home_Work.DAL.Infrastructure;
using Home_Work.DAL.Repositories;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
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

        [HttpGet]
        public ActionResult GetStudent()
        {
            ViewBag.Student = repository.Select();

            return View();
        }

        [HttpGet]
        public ActionResult UpDate(int id)
        {
            var studentModel = repository.GetById(id);
            return View(studentModel);
        }

        [HttpPost]
        public ActionResult UpDate(int id, string name, string lastName, string yearOfStudy)
        {

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(yearOfStudy))
            {
                TempData["SM"] = "не удалось обновить Студента!";
            }
            else
            {
                repository.UpDate(id, name, lastName, yearOfStudy);
                //TempData["SM"] = "Вы обновили Студента!";
            }

            ViewBag.Student = repository.Select();
            return View("GetStudent");
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
                TempData["SM"] = "Одно из полей пустое!";

                ViewBag.Message = "alert-danger";
                return View();
            }
            else
            {

                var students = repository.Select().ToArray();

                for (int i = 0; i < students.LongCount(); i++)
                {
                    if (students[i].FirstName == name && students[i].LastName == lastname)
                    {
                        TempData["SM"] = "Такой студент уже есть!";

                        ViewBag.Message = "alert-danger";

                        return View();
                    }

                }

                var regex = new Regex(@"^[0-9]+$");

                if(regex.IsMatch(name) || regex.IsMatch(lastname))
                {

                    TempData["SM"] = "В имени или фамилии не должно быть чисел!";

                    ViewBag.Message = "alert-danger";

                    return View();

                }

                repository.CreateNewStudent(name, lastname, yearOfStudy);
                ViewBag.Message = "alert-success";
                TempData["SM"] = "Вы создали Студента!";
            }

            return View();
        }

        //public ActionResult Delete(int id)
        //{
        //    repository.Delete(id);

        //    TempData["SM"] = "Вы удалили студента";

        //    ViewBag.Student = repository.Select();
        //    return View("GetStudent");
        //}

    }
}