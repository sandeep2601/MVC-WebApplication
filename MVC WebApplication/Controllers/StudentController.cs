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
    }
}