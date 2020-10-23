using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
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
        [Display(Name = "One Time Pick Up Date")]
        public DateTime OneTimePickUp { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Temporary Suspension Start Date")]
        public DateTime SuspensionStartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Temporary Suspension End Date")]
        public DateTime SuspensionEndDate { get; set; }
        [Display(Name = "Has Been Picked Up")]
        public bool isPickedUp { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        
    }
}
