using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Installed  entity framework 6 below by going to
//Tools > Manage Nuget Packages > Microsoft Entity Framework (ver 6.4)
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPWebApp.Models
{
    public class Furniture
    {
        /*

            Information for "entities".

            -FURNITURE PRODUCT ENTITY

            A furniture product is an item that people/women can use in their office. 
            Chair - They can sit on a chair to do work
            Table - They can put their items on a desk and also do work on a desk 

            Things that describe a furniture product entity are:

                - Price
                - Name
                - Description
                - Height
                - Width
                - Depth
                - Weight
                - Color
                - Picture(s)
        
            A furniture product must reference:
                - A category name
        */


        [Key]
        public int Id { get; set; }

        public int Price { get; set; }
        //Cost is in Cents rather than dollars (i.e. 1000c = $10.00)
        //currency is in CANADIAN (CAD)

        public string Name { get; set; }

        public string Description { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Depth { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }


        //haspic can be 0 or 1 indicating (1) => has picture (0)=> no picture
        //Content/Pets/{id}.{PicExtension}
        public int HasPic { get; set; }
        //.jpg, .gif. .png, .jpeg
        public string PicExtension { get; set; }


        //Represents the many in (one category to many furniture products)        
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

    }
}