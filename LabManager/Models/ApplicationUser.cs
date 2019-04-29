using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LabManager.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name ="Hire Date")]
        public DateTime HireDate { get; set; }


        // Set up PK -> FK relationships to other objects
        public virtual ICollection<LabThing> LabThings { get; set; }

        public virtual ICollection<Chemical> Chemicals { get; set; }
    }
}