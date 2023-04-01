using Home_Work.DAL.Infrastructure;
using Home_Work.DAL.Repositories;
using Ninject;
using System.Net.Http;
using System.Web.Http;

namespace Home_Work.DAL.Controllers
{

    class StudentApiController : ApiController
    {

        private readonly IRepositoryInterface repository;

        public StudentApiController(IRepositoryInterface repository)
        {
            this.repository = repository;
        }

        public HttpResponseMessage GetStudentSerialize()
        {


            string obgjson = System.Text.Json.JsonSerializer.Serialize(repository.Select());

            var response = Request.CreateResponse(obgjson);

            return response;
        }

    }
}