using Home_Work.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Home_Work.DAL.Context
{
    public class StudentContext: DbContext
    {
       
        public StudentContext():base("firstConnect")
        {}

        public DbSet<Student> Students { get; set; }
    }
}