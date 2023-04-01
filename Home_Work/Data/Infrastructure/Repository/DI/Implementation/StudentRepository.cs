using Home_Work.DAL.Infrastructure;
using Home_Work.DAL.Models;
using Home_Work.Data.Infrastructure.Repository.DI.Implementation;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Home_Work.DAL.Repositories
{
    public class StudentRepository : IRepositoryInterface
    {
        string connection_string = "Data Source=NORM-GELEZO;Initial Catalog=Student;Persist Security Info=true;User ID=student;Password=student";


        public void CreateNewStudent(string name, string lastname, string yearOfStudy)
        {
            using (var sqlConnection = new SqlConnection(connection_string))
            {
                sqlConnection.Open();

                using (var cmd = new SqlCommand(StudentSqlCreator.ForCreate(name, lastname, yearOfStudy).SqlText, sqlConnection))
                {
                    var reader = cmd.ExecuteNonQuery();

                    cmd.CommandType = CommandType.Text;

                }
            }

        }

        public void Delete(int id)
        {
            using (var sqlConnection = new SqlConnection(connection_string))
            {
                sqlConnection.Open();

                using (var cmd = new SqlCommand(StudentSqlCreator.ForDelete(id).SqlText, sqlConnection))
                {
                    var reader = cmd.ExecuteReader();

                    cmd.CommandType = CommandType.Text;

                }
            }
        }

        public Student Get(int id)
        {
            using (var sqlConnection = new SqlConnection(connection_string))
            {
                sqlConnection.Open();

                using (var cmd = new SqlCommand(StudentSqlCreator.GetById(id).SqlText, sqlConnection))
                {
                    var reader = cmd.ExecuteReader();

                    cmd.CommandType = CommandType.Text;

                    Student model = new Student();
                    if (reader.Read())
                    {
                        model.StudentID = reader.GetInt32(0);
                        model.FirstName = reader.GetString(1).ToString();
                        model.LastName = reader.GetString(2).ToString();
                        model.YearOfStudy = reader.GetString(3).ToString();
                    }
                    return model;
                }
            }
        }

        public Student GetByName(string name)
        {
            using (var sqlConnection = new SqlConnection(connection_string))
            {
                sqlConnection.Open();

                using (var cmd = new SqlCommand(StudentSqlCreator.GetByName(name).SqlText, sqlConnection))
                {
                    var reader = cmd.ExecuteReader();

                    cmd.CommandType = CommandType.Text;

                    Student model = new Student();
                    if (reader.Read())
                    {
                        model.StudentID = reader.GetInt32(0);
                        model.FirstName = reader.GetString(1).ToString();
                        model.LastName = reader.GetString(2).ToString();
                        model.YearOfStudy = reader.GetString(3).ToString();
                    }
                    return model;
                }
            }
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

                    var students = new List<Student>();
                    while (reader.Read())
                    {
                        Student model = new Student();
                        model.StudentID = reader.GetInt32(0);
                        model.FirstName = reader.GetString(1).ToString();
                        model.LastName = reader.GetString(2).ToString();
                        model.YearOfStudy = reader.GetString(3).ToString();
                        students.Add(model);
                    }

                    return students;
                }

            }

        }
    }
}