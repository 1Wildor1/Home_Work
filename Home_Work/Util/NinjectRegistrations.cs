using Home_Work.DAL.Infrastructure;
using Home_Work.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home_Work.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositoryInterface>().To<StudentRepository>();
        }
    }
}