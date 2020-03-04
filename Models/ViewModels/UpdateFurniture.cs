using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPWebApp.Models.ViewModels
{
    public class UpdateFurniture
    {

    
        
        //we need the furniture info and a list of categories

        public Furniture Furniture { get; set; }
        public List<Category> Category { get; set; }


    }
}