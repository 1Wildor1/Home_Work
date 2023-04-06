using Azure.Core;
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

        //Get___________________________________
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

        //UpDate________________________________
        [HttpPost]
        public ActionResult UpDate(int id, string name, string lastName, string yearOfStudy)
        {
                var studentArray = repository.Select();
                var examination = studentArray.FirstOrDefault(x => x.StudentID == id);
            try
            {

                if (examination == null)
                {
                    TempData["SM"] = "такого пользователя нет!";

                    ViewBag.Message = "alert-danger";
                    var studentModel1 = repository.GetById(id);
                    return View(studentModel1);
                }

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(yearOfStudy))
                {
                    TempData["SM"] = "Одно из полей пустое!";

                    ViewBag.Message = "alert-danger";
                    var studentModel1 = repository.GetById(id);
                    return View(studentModel1);

                }

                var regex = new Regex(@"^[а-яА-ЯёЁa-zA-Z]*$");

                if (!regex.IsMatch(name) || !regex.IsMatch(lastName))
                {
                    TempData["SM"] = "В имени или фамилии не должно быть чисел и спецсимволов!";

                    ViewBag.Message = "alert-danger";
                    var studentModel1 = repository.GetById(id);
                    return View(studentModel1);
                }

                var students = repository.Select().ToArray();

                for (int i = 0; i < students.LongCount(); i++)
                {
                    if (students[i].FirstName == name && students[i].LastName == lastName)
                    {
                        TempData["SM"] = "Такой студент уже есть!";

                        ViewBag.Message = "alert-danger";

                        var studentModel1 = repository.GetById(id);
                        return View(studentModel1);
                    }
                }

            }
            catch (Exception ex)
            {
                TempData["SM"] = ex.Message.ToString();
                ViewBag.Message = "alert-danger";
                var studentModel1 = repository.GetById(id);
                return View(studentModel1);
            }
            repository.UpDate(id, name, lastName, yearOfStudy);
            var studentModel = repository.GetById(id);
            ViewBag.Message = "alert-success";
            TempData["SM"] = "Вы обновили Студента!";
            return View(studentModel);
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            return View();
        }

        //Create_______________________
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

                var regex = new Regex(@"^[а-яА-ЯёЁa-zA-Z]*$");

                if (!regex.IsMatch(name) || !regex.IsMatch(lastname))
                {
                    TempData["SM"] = "В имени или фамилии не должно быть чисел и спецсимволов!";

                    ViewBag.Message = "alert-danger";

                    return View();
                }

                try
                {
                    repository.CreateNewStudent(name, lastname, yearOfStudy);
                    ViewBag.Message = "alert-success";
                    TempData["SM"] = "Вы создали Студента!";
                }
                catch (Exception ex)
                {

                    TempData["SM"] = ex.Message.ToString();
                    ViewBag.Message = "alert-danger";
                    return View();
                }
            }

            return View();
        }

        //Delete______________
        public ActionResult Delete(int id)
        {

            var studentArray = repository.Select();
            var examination = studentArray.FirstOrDefault(x => x.StudentID == id);

            if (examination == null)
            {
                TempData["SM"] = "такого пользователя нет!";

                ViewBag.Message = "alert-danger";
                ViewBag.Student = repository.Select();
                return View("GetStudent");
            }
            try
            {
                repository.Delete(id);

            }
            catch (Exception ex)
            {
                TempData["SM"] = ex.Message.ToString();
                ViewBag.Student = repository.Select();
                return View("GetStudent");
            }

            ViewBag.Message = "alert-success";
            ViewBag.Student = repository.Select(); 
            return View("GetStudent");
        }

       

    }
}