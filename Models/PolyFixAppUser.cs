using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Poly.Models;

namespace PolyFix.Models
{
    // Add profile data for application users by adding properties to the IdentityUserclass
    public class PolyFixAppUser : IdentityUser 
    {
        
        [PersonalData]
        [Display(Name = "First Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Display(Name = "Surname")]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Display(Name = "Profile Picture")]
        public byte[] ProfilePicture { get; set; }

        public virtual ICollection<UserProject> UserProject { get; set; }

        public virtual ICollection<UserTask> UserTask { get; set; }

    }



   
}
