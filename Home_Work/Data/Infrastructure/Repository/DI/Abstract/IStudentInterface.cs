using Home_Work.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.DAL.Infrastructure
{
    public interface IStudentInterface:IBaseInterface<Student>
    {
        Student GetByName(string name);
    }
}
