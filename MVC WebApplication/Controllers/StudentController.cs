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
        public ActionResult Student(tbl_Student model)
        {
            if (model != null)
                return View(model);
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(tbl_Student model)
        {
            if (ModelState.IsValid)
            {
                tbl_Student student = new tbl_Student();
                student.ID = model.ID;
                student.Name = model.Name;
                student.FName = model.FName;
                student.Email = model.Email;
                student.Mobile = model.Mobile;
                student.Description = model.Description;

                if (model.ID == 0)
                {
                    dBEntities.tbl_Student.Add(student);
                    dBEntities.SaveChanges();
                }
                else
                {
                    dBEntities.Entry(student).State = System.Data.Entity.EntityState.Modified;
                    dBEntities.SaveChanges();
                }

            }
            ModelState.Clear();

            return View("Student");
        }

        public ActionResult StudentList()
        {
            var result = dBEntities.tbl_Student.ToList();
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            var result = dBEntities.tbl_Student.Where(x => x.ID == id).First();
            dBEntities.tbl_Student.Remove(result);
            dBEntities.SaveChanges();

            var updatedList = dBEntities.tbl_Student.ToList();
            return View("StudentList", updatedList);
        }
    }
}