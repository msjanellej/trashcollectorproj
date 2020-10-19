using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        [Display(Name = "Pick Up Day")]
        public string PickUpDay { get; set; }
        [Display (Name = "Balance Due")]
        public double BalanceDue { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Select One Time Pick Up Date")]
        public DateTime OneTimePickUp { get; set; }



        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser Identity { get; set; }
    }
}
