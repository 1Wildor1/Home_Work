using Home_Work.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.DAL.Infrastructure
{
    internal interface IBaseInterface<T>
    {
        bool Create(T entity);
        T Get(int id);
        List<Student> Select();
        bool Delete(int id);
    }
}
