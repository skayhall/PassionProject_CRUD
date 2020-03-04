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
        public ActionResult Add()
        {
            return View();
        }

        //add the parameters - form field id's
        [HttpPost] 
        public ActionResult New(string catname)
        {
            //write query to insert into category
            string query = "INSERT INTO categories (Name) values (@catname)  ";
            Debug.WriteLine("I am trying to add the" + catname);

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
            //going to the database and getting the categories
            List<Category> categories = db.Category.SqlQuery("SELECT * FROM categories").ToList();

            return View(categories);
            //provides a list of categories
        }


        public ActionResult Show(int id)
        {
            string query = "SELECT * FROM categories where id = @id";
            var parameter = new SqlParameter("@id", id);
            Category selectedcategory = db.Category.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedcategory);
        }




        //DELETE 
        public ActionResult DeleteConfirm(int id)
        {
            string query = "select * from categories where id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Category selectedcategories = db.Category.SqlQuery(query, param).FirstOrDefault();
            return View(selectedcategories);
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string query = "DELETE FROM categories where id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);


            //string refquery = "UPDATE categories set id = '' where id=@id";
            //db.Database.ExecuteSqlCommand(refquery, param);

            return RedirectToAction("List");
        }


    }

}