using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PPWebApp.Models
{
    public class Booking
    {


        /*

    A booking is an agreement between the customer and the company who owns the app
    It outlines all the furniture that is being rented by a customer. 

    Some things that describe a Booking
        - Booking ID
        - Booking Title
        - Start date and time
        - End date and time
        - Notes

*/

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Notes { get; set; }



    }
}