using Home_Work.DAL.Models;
using Home_Work.Data.Models;
using System.Collections.Generic;

namespace Home_Work.DAL.Infrastructure
{
    public interface IBaseInterface<T>
    {
        bool CreateNewStudent(string name, string lastname, string yearOfStudy);
        T Get(int id);
        List<Student> Select();
        bool Delete(int id);
    }
}
