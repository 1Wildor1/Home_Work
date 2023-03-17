using Home_Work.DAL.Context;
using Home_Work.DAL.Infrastructure;
using Home_Work.DAL.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Web;

namespace Home_Work.DAL.Repositories
{
    public class StudentRepository : IStudentInterface
    {
        string connection_string = "Data Source=NORM-GELEZO;Initial Catalog=Student;Persist Security Info=true;User ID=student;Password=student";

        private StudentContext db;

       
        public bool Create(Student entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }

        public Student GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Student> Select()
        {
           


            using (var sqlConnection = new SqlConnection(connection_string))
            {
                sqlConnection.Open();

                using (var cmd = new SqlCommand("select * from tbl_Student", sqlConnection))
                {

                    var reader = cmd.ExecuteReader();

                    cmd.CommandType = CommandType.Text;

                        var sudents = new List<Student>();
                    while (reader.Read())
                    {
                        Student model = new Student();
                        model.StudentID = reader.GetInt32(0);
                        model.FirstName = reader.GetString(1).ToString();
                        model.LastName = reader.GetString(2).ToString();
                        model.YearOfStudy = reader.GetString(3).ToString();
                        sudents.Add(model);
                    }


                    return sudents;
                } 
              
            }

        }
    }
}