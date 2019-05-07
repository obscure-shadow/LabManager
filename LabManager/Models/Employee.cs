using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
//NOTE: This is the "ApplicationUser" file. I renamed it "Employee" because the employee is the application user that requires Identity authorization.
namespace LabManager.Models
{
    // Add profile data for application users by adding properties to the Employee class
    public class Employee : IdentityUser
    {
        public Employee() { }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Hire Date")]
        public System.DateTime HireDate { get; set; }
    }
}