using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPWebApp.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        //Represents the "many" in (one category to many furniture products)
        public ICollection<Furniture> Furniture { get; set; }




    }
}