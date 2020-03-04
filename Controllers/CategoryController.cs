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


        // Go to the add and return the view
        //function, insert parameters and do something with it
        public ActionResult Add()
        {

            return View();
        }

        //add the parameters - form field id's
        [HttpPost] //POSTED from form
        public ActionResult New(string catname)
        {
            //write query to insert into category
            string query =
                "INSERT INTO categories (Name) values (@catname)  ";
            Debug.WriteLine("I am trying to add the" + catname);

            //
            SqlParameter[] Sqlparams = new SqlParameter[1]; // number of fields
            Sqlparams[0] = new SqlParameter("@catname", catname); //first matches the name we give above and the second matches the id from the form



            //execute the query
            db.Database.ExecuteSqlCommand(query, Sqlparams);
            Debug.WriteLine("I am trying to add the" + catname);
            //return/redirect to the list
            return RedirectToAction("List");

        }


        public ActionResult New()
        {
            List<Category> category = db.Category.SqlQuery("SELECT * FROM Categories").ToList();

            return View(category);
        }


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