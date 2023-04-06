using Home_Work.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.DAL.Infrastructure
{
    public interface IRepositoryInterface
    {
        void CreateNewStudent(string name, string lastname, string yearOfStudy);
        Student GetByName(string name);
        void UpDate(int id, string name, string lastName, string YearOfStudy);
        Student GetById(int id);
        List<Student> Select();
        void Delete(int id);
    }
}
