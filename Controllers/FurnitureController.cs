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
        // GET: Furniture
        public ActionResult Random()
        {

            var furniture = new Furniture()
            {
                Name = "Fuzzy Elenora Side Chair"
            };

            return View(furniture); //passing/return furniture view
        }


        public PpWebAppContext db = new PpWebAppContext();

        // GET: Furniture
        public ActionResult List()
        {
           
            List<Furniture> furniture = db.Furniture.SqlQuery("SELECT * FROM Furniture").ToList();
            return View(furniture);

        }




    }

}