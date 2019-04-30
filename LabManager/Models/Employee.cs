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
        [Display(Name ="Hire Date")]
        public System.DateTime HireDate { get; set; }


        // Set up PK -> FK relationships to other objects
        //public virtual ICollection<LabThing> LabThings { get; set; }
        //public virtual ICollection<Chemical> Chemicals { get; set; }
    }
}