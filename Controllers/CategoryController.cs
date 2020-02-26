using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPWebApp.Data;
using PPWebApp.Models;
//using PPWebApp.Models.ViewModels;
using System.Diagnostics;
using System.IO;

namespace PPWebApp.Controllers
{
    public class CategoryController : Controller
    {
        
        
        public PpWebAppContext db = new PpWebAppContext();


        // GET: Category
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {

            //categories is going to database and get the categories
            List<Category> categories = db.Category.SqlQuery("SELECT * FROM categories").ToList();

            return View(categories);
            //provides a list of categories

        }



    }

}