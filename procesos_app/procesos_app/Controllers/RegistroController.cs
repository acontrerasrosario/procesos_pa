using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using procesos_app.Models;

namespace procesos_app.Controllers
{
    public class RegistroController : Controller
    {

        ApplicationDbContext _context;

        public void ApplicationDbContext()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Registro
        public ActionResult Index()
        {
            
            return View();
        }

    }
}