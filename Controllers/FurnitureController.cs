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
    public class FurnitureController : Controller
    {


        //generate database first
        public PpWebAppContext db = new PpWebAppContext();


        // Go to the add and return the view
        //function, insert parameters and do something with it
        public ActionResult Add()
        {

            return View();
        }

        //add the parameters - form field id's
        [HttpPost] //POSTED from form
        public ActionResult New(string furname, int furprice, string furdescription, int furheight, int furwidth, int furdepth, int furweight, string furcolor, int CategoryID)
        {
            //write query to insert into furniture
            string query =
                "INSERT INTO furnitures (Name, Price, Description, Height, Width, Depth, Weight, Color, CategoryID) values (@furname, @furprice, @furdescription, @furheight, @furwidth, @furdepth, @furweight, @furcolor, @CategoryID)  ";
            Debug.WriteLine("I am trying to add the" + furname);

            //parameterize the query (treat special characters as normal text exp - & and ''. Also lessons chances of hacking.  
            SqlParameter[] Sqlparams = new SqlParameter[9]; // number of fields
            Sqlparams[0] = new SqlParameter("@furname", furname); //first matches the name we give above and the second matches the id from the form
            Sqlparams[1] = new SqlParameter("@furprice", furprice);
            Sqlparams[2] = new SqlParameter("@furdescription", furdescription);
            Sqlparams[3] = new SqlParameter("@furheight", furheight);
            Sqlparams[4] = new SqlParameter("@furwidth", furwidth);
            Sqlparams[5] = new SqlParameter("@furdepth", furdepth);
            Sqlparams[6] = new SqlParameter("@furweight", furweight);
            Sqlparams[7] = new SqlParameter("@furcolor", furcolor);
            Sqlparams[8] = new SqlParameter("@CategoryID", CategoryID);
            

            //execute the query
            db.Database.ExecuteSqlCommand(query, Sqlparams);
            Debug.WriteLine("I am trying to add the" + furname);
            //return/redirect to the list
            return RedirectToAction("List");

        }


        public ActionResult New()
        {
            //STEP 1: PUSH DATA!
            //What data does the Add.cshtml page need to display the interface?
            //A list of species to choose for a pet

            //alternative way of writing SQL -- will learn more about this week 4
            //List<Species> Species = db.Species.ToList();

            List<Category> category = db.Category.SqlQuery("SELECT * FROM Categories").ToList();

            return View(category);
        }





        // GET: Furniture

        public ActionResult List()
        {
           
            List<Furniture> furniture = db.Furniture.SqlQuery("SELECT * FROM Furnitures").ToList();
            return View(furniture);

        }





    }

}