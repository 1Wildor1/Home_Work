using Home_Work.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home_Work.Data.Infrastructure.Repository.DI.Implementation
{
    public class StudentSqlCreator
    {
        public static StudentSql ForCreate(string name, string lastname, string yearOfStudy)
        {
            return new StudentSql()
            {
                SqlText = $"insert into tbl_Student (FirstName, LastName, YearOfStudy) Values('{name}', '{lastname}','{yearOfStudy}');",
                SqlParams = new object[] { }
            };
        }

        public static StudentSql ForDelete(int id)
        {
            return new StudentSql()
            {
                SqlText = $"DELETE FROM tbl_Student WHERE StudentID = {id};",
                SqlParams = new object[] { }
            };
        }

        public static StudentSql GetById(int id)
        {
            return new StudentSql()
            {
                SqlText = $"Select * From tbl_Student where StudentID = {id};",
                SqlParams = new object[] { }
            };
        }

        public static StudentSql GetByName(string name)
        {
            return new StudentSql()
            {
                SqlText = $"Select * From tbl_Student where FirstName = {name};",
                SqlParams = new object[] { }
            };
        }
    }
}