using Home_Work.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Home_Work.StudentApp.Controllers.Api
{
    public class StudentApi : ApiController
    {
        private readonly IRepositoryInterface repository;

        public StudentApi(IRepositoryInterface repository)
        {
            this.repository = repository;
        }

        public void Delete(int id)
        {
            repository.Delete(id);

        }
    }
}