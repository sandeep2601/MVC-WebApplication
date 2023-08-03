using MVC_WebApplication.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_WebApplication.Controllers
{
    public class StudentController : Controller
    {
        MVC_Test_DBEntities dBEntities = new MVC_Test_DBEntities();

        // GET: Student
        public ActionResult Student()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(tbl_Student model)
        {
            tbl_Student student = new tbl_Student();
            student.Name = model.Name;
            student.FName = model.FName;
            student.Email = model.Email;
            student.Mobile = model.Mobile;
            student.Description = model.Description;

            dBEntities.tbl_Student.Add(student);
            dBEntities.SaveChanges();

            return View("Student");
        }
    }
}